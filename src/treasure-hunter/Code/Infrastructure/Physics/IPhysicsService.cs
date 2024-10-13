using System.Collections.Generic;
using Godot;

namespace Code.Infrastructure.Physics;

public struct Hit2D<TEntity> where TEntity : class
{
  public TEntity Entity;
  public Vector2 Position;
  public Vector2 Normal;
  public GodotObject Collider;
  public ulong ColliderId;
  public int Shape;
  public Rid Rid;
}

public struct Overlap2D<TEntity> where TEntity : class
{
  public TEntity Entity;
  public ulong ColliderId;
  public Vector2 Position;
  public Vector2 Normal;
  public Vector2 LinearVelocity;
  public int Shape;
  public Rid Rid;
}

public interface IPhysicsService
{
  Hit2D<TEntity> RayCast<TEntity>(Vector2 worldPosition, Vector2 direction, uint layerMask = uint.MaxValue) where TEntity : class;
    
  IEnumerable<Hit2D<TEntity>> RayCastAll<TEntity>(Vector2 worldPosition, Vector2 direction, uint layerMask = uint.MaxValue) where TEntity : class;
    
  Hit2D<TEntity> LineCast<TEntity>(Vector2 start, Vector2 end, uint layerMask = uint.MaxValue) where TEntity : class;
    
  IEnumerable<Hit2D<TEntity>> LineCastAll<TEntity>(Vector2 start, Vector2 end, uint layerMask = uint.MaxValue) where TEntity : class;
  
  Overlap2D<TEntity> OverlapCircle<TEntity>(Transform2D transform2D, float radius, uint layerMask = uint.MaxValue) where TEntity : class;
  IEnumerable<Overlap2D<TEntity>> OverlapCircleAll<TEntity>(Transform2D transform2D, float radius, uint layerMask = uint.MaxValue) where TEntity : class;

  Overlap2D<TEntity> OverlapBox<TEntity>(Transform2D transform2D, Vector2 size, uint layerMask = uint.MaxValue) where TEntity : class;
  IEnumerable<Overlap2D<TEntity>> OverlapBoxAll<TEntity>(Transform2D transform2D, Vector2 size, uint layerMask = uint.MaxValue) where TEntity : class;
}