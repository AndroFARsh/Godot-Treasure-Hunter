using System;
using System.Collections.Generic;
using Code.Projects.Providers.Game;
using Godot;
using Godot.Collections;

namespace Code.Infrastructure.Physics;

public class GodotPhysicsService : IPhysicsService, IDisposable
{
  private readonly Array<Rid> _excludeArray = new();
  private readonly Stack<PhysicsRayQueryParameters2D> _rayQueryPool = new();
  private readonly Stack<PhysicsShapeQueryParameters2D> _shapeQueryPool = new();
  private readonly Stack<Rid> _circleShapePool = new();
  private readonly Stack<Rid> _rectShapePool = new();
  
  private readonly IGameRootProvider _gameRootProvider;
  private readonly IEntityResolverFromCollider _colliderResolver;

  private PhysicsDirectSpaceState2D PhysicsDirectSpace => 
    _gameRootProvider.Root?.GetWorld2D()?.DirectSpaceState;
  

  public GodotPhysicsService(IGameRootProvider gameRootProvider, IEntityResolverFromCollider colliderResolver)
  {
    _gameRootProvider = gameRootProvider;
    _colliderResolver = colliderResolver;
  }
  
  public void Dispose()
  {
      foreach(Rid shapeRid in _circleShapePool)
        PhysicsServer2D.FreeRid(shapeRid);
      
      foreach(Rid shapeRid in _rectShapePool)
        PhysicsServer2D.FreeRid(shapeRid);
      
      _circleShapePool.Clear();
      _shapeQueryPool.Clear();
      _excludeArray.Clear();
      _rayQueryPool.Clear();
      _shapeQueryPool.Clear();
  }

  private bool TryLineCast<TEntity>(
    Vector2 from,
    Vector2 to,
    uint layerMask,
    Array<Rid> exclude,
    out Hit2D<TEntity> result
  ) where TEntity : class
  {
    result = default;
    
    if (!_rayQueryPool.TryPop(out PhysicsRayQueryParameters2D query)) query = new PhysicsRayQueryParameters2D();
    
    query.From = from;
    query.To = to;
    query.CollisionMask = layerMask;
    query.Exclude = exclude;
    
    Dictionary dictionary = PhysicsDirectSpace.IntersectRay(query);
    if (dictionary.TryGetValue("collider_id", out Variant colliderId))
    {
      result.Entity = _colliderResolver.Resolve<TEntity>(colliderId.AsUInt64());
      result.ColliderId = colliderId.AsUInt64();
      result.Collider = dictionary["collider"].AsGodotObject();
      result.Position = dictionary["position"].AsVector2();
      result.Normal = dictionary["normal"].AsVector2();
      result.Rid = dictionary["rid"].AsRid();
      result.Shape = dictionary["shape"].AsInt32();
      return true;
    }
    
    _rayQueryPool.Push(query);
    return false;
  }

  public Hit2D<TEntity> RayCast<TEntity>(Vector2 start, Vector2 direction, uint layerMask) where TEntity : class 
    => LineCast<TEntity>(start, start + direction, layerMask);

  public IEnumerable<Hit2D<TEntity>> RayCastAll<TEntity>(Vector2 start, Vector2 direction, uint layerMask) where TEntity : class
    => LineCastAll<TEntity>(start, start + direction, layerMask);
  
  public Hit2D<TEntity> LineCast<TEntity>(Vector2 start, Vector2 end, uint layerMask) where TEntity : class
    => TryLineCast(start, end, layerMask, default, out Hit2D<TEntity> hit) ? hit : default;

  public IEnumerable<Hit2D<TEntity>> LineCastAll<TEntity>(Vector2 start, Vector2 end, uint layerMask) where TEntity : class
  {
    _excludeArray.Clear();
    while (TryLineCast(start, end, layerMask, _excludeArray, out Hit2D<TEntity> hit))
    {
      yield return hit;
      
      start = hit.Position;
      
      _excludeArray.Add(hit.Rid);
      if (end.DistanceTo(start) < 0.01f)
        yield break;
    }
  }

  private bool TryOverlapShape<TEntity>(
    Transform2D transform2D, 
    Rid shapeRid, 
    uint layerMask, 
    Array<Rid> exclude, 
    out Overlap2D<TEntity> result)
    where TEntity : class
  {
    if (!_shapeQueryPool.TryPop(out PhysicsShapeQueryParameters2D query)) query = new PhysicsShapeQueryParameters2D();

    result = default;
    
    query.ShapeRid = shapeRid;
    query.Transform = transform2D;
    query.CollisionMask = layerMask;
    query.Exclude = exclude;
    
    Dictionary dictionary = PhysicsDirectSpace.GetRestInfo(query);
    
    _shapeQueryPool.Push(query);
    if (dictionary.TryGetValue("collider_id", out Variant colliderId))
    {
      result.Entity = _colliderResolver.Resolve<TEntity>(colliderId.AsUInt64());
      result.ColliderId = colliderId.AsUInt64();
      result.Rid = dictionary["rid"].AsRid();
      result.Shape = dictionary["shape"].AsInt32();
      result.Position = dictionary["point"].AsVector2();
      result.Normal = dictionary["normal"].AsVector2();
      result.LinearVelocity = dictionary["linear_velocity"].AsVector2();
      
      return true;
    }

    return false;
  }

  public Overlap2D<TEntity> OverlapCircle<TEntity>(Transform2D transform2D, float radius, uint layerMask = UInt32.MaxValue) where TEntity : class
  {
    if (!_circleShapePool.TryPop(out Rid shapeRid)) shapeRid = PhysicsServer2D.CircleShapeCreate();
    PhysicsServer2D.ShapeSetData(shapeRid, radius);

    TryOverlapShape(transform2D, shapeRid, layerMask, default, out Overlap2D<TEntity> result);
    
    _circleShapePool.Push(shapeRid);
    return result;
  }

  public IEnumerable<Overlap2D<TEntity>> OverlapCircleAll<TEntity>(Transform2D transform2D, float radius, uint layerMask = UInt32.MaxValue) where TEntity : class
  {
    _excludeArray.Clear();
    if (!_circleShapePool.TryPop(out Rid shapeRid)) shapeRid = PhysicsServer2D.CircleShapeCreate();
    PhysicsServer2D.ShapeSetData(shapeRid, radius);

    while (TryOverlapShape(transform2D, shapeRid, layerMask, _excludeArray, out Overlap2D<TEntity> result))
    {
      yield return result;
      _excludeArray.Add(result.Rid);
    }

    _circleShapePool.Push(shapeRid);
  }

  public Overlap2D<TEntity> OverlapBox<TEntity>(Transform2D transform2D, Vector2 size, uint layerMask = UInt32.MaxValue) where TEntity : class
  {
    if (!_rectShapePool.TryPop(out Rid shapeRid)) shapeRid = PhysicsServer2D.RectangleShapeCreate();
    PhysicsServer2D.ShapeSetData(shapeRid, size / 2);

    TryOverlapShape(transform2D, shapeRid, layerMask, default, out Overlap2D<TEntity> result);
    
    _rectShapePool.Push(shapeRid);
    return result;
  }

  public IEnumerable<Overlap2D<TEntity>> OverlapBoxAll<TEntity>(Transform2D transform2D, Vector2 size, uint layerMask = UInt32.MaxValue) where TEntity : class
  {
    _excludeArray.Clear();
    if (!_rectShapePool.TryPop(out Rid shapeRid)) shapeRid = PhysicsServer2D.RectangleShapeCreate();
    PhysicsServer2D.ShapeSetData(shapeRid, size / 2);

    while (TryOverlapShape(transform2D, shapeRid, layerMask, _excludeArray, out Overlap2D<TEntity> result))
    {
      yield return result;
      _excludeArray.Add(result.Rid);
    }

    _rectShapePool.Push(shapeRid);
  }
}