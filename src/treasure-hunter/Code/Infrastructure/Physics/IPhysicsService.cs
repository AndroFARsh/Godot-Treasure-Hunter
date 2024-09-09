using System.Collections.Generic;
using Godot;

namespace Code.Infrastructure.Physics
{
  public interface IPhysicsService
  {
    TEntity RayCast<TEntity>(Vector2 worldPosition, Vector2 direction, int layerMask) where TEntity : class;
    
    IEnumerable<TEntity> RayCastAll<TEntity>(Vector2 worldPosition, Vector2 direction, int layerMask) where TEntity : class;
    
    TEntity LineCast<TEntity>(Vector2 start, Vector2 end, int layerMask) where TEntity : class;
    
    IEnumerable<TEntity> LineCastAll<TEntity>(Vector2 start, Vector2 end, int layerMask) where TEntity : class;
    
    TEntity CircleCast<TEntity>(Vector2 position, float radius, Vector2 direction, int layerMask) where TEntity : class;
    
    IEnumerable<TEntity> CircleCastAll<TEntity>(Vector2 position, float radius, Vector2 direction, int layerMask) where TEntity : class;

    TEntity BoxCast<TEntity>(Vector2 position, Vector2 size, float angle, Vector2 direction, int layerMask) where TEntity : class;
    
    IEnumerable<TEntity> BoxCastAll<TEntity>(Vector2 position, Vector2 size, float angle, Vector2 direction, int layerMask) where TEntity : class;
    
    TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class;
    IEnumerable<TEntity> OverlapPointAll<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class;
   
    TEntity OverlapCircle<TEntity>(Vector2 worldPos, float radius, int layerMask) where TEntity : class;
    IEnumerable<TEntity> OverlapCircleAll<TEntity>(Vector2 worldPos, float radius, int layerMask) where TEntity : class;

    TEntity OverlapBox<TEntity>(Vector2 worldPosition, Vector2 size, float angle, int layerMask) where TEntity : class;
    IEnumerable<TEntity> OverlapBoxAll<TEntity>(Vector2 worldPosition, Vector2 size, float angle, int layerMask) where TEntity : class;

    TEntity OverlapArea<TEntity>(Vector2 worldPosition, Vector2 size, int layerMask) where TEntity : class;
    IEnumerable<TEntity> OverlapAreaAll<TEntity>(Vector2 worldPosition, Vector2 size, int layerMask) where TEntity : class;
    
    // TEntity OverlapCollider<TEntity>(Collider2D collider, int layerMask) where TEntity : class;
    // IEnumerable<TEntity> OverlapColliderAll<TEntity>(Collider2D collider, int layerMask) where TEntity : class;
  }
}