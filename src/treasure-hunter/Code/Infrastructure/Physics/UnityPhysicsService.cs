// using System.Collections.Generic;
// using Godot;
// using TreasureHunter.Code.Infrastructure.Physics;
//
// namespace Code.Infrastructure.Physics
// {
//   public class UnityPhysicsService : IPhysicsService
//   {
//     private static readonly RaycastHit2D[] _hits = new RaycastHit2D[128];
//     private static readonly Collider2D[] _overlapHits = new Collider2D[128];
//
//     private readonly IEntityResolverFromCollider _resolver;
//
//     public UnityPhysicsService(IEntityResolverFromCollider resolver)
//     {
//       _resolver = resolver;
//     }
//
//     public TEntity RayCast<TEntity>(Vector2 worldPosition, Vector2 direction, int layerMask) where TEntity : class
//     {
//       RaycastHit2D hit = Physics2D.Raycast(worldPosition, direction, float.PositiveInfinity, layerMask);
//       return hit.collider != null 
//         ? _resolver.Resolve<TEntity>(hit.collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> RayCastAll<TEntity>(Vector2 worldPosition, Vector2 direction, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.RaycastNonAlloc(worldPosition, direction, _hits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         RaycastHit2D hit = _hits[i];
//         if (hit.collider == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.collider.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//
//     public TEntity LineCast<TEntity>(Vector2 start, Vector2 end, int layerMask) where TEntity : class
//     {
//       RaycastHit2D hit = Physics2D.Linecast(start, end, layerMask);
//       return hit.collider != null 
//         ? _resolver.Resolve<TEntity>(hit.collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> LineCastAll<TEntity>(Vector2 start, Vector2 end, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.LinecastNonAlloc(start, end, _hits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         RaycastHit2D hit = _hits[i];
//         if (hit.collider == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.collider.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//     
//     public TEntity CircleCast<TEntity>(Vector2 position, float radius, Vector2 direction, int layerMask) where TEntity : class
//     {
//       RaycastHit2D hit = Physics2D.CircleCast(position, radius, direction, float.PositiveInfinity, layerMask);
//       return hit.collider != null 
//         ? _resolver.Resolve<TEntity>(hit.collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> CircleCastAll<TEntity>(Vector2 position, float radius, Vector2 direction, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.CircleCastNonAlloc(position, radius, direction, _hits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         RaycastHit2D hit = _hits[i];
//         if (hit.collider == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.collider.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//
//     public TEntity BoxCast<TEntity>(Vector2 position, Vector2 size, float angle, Vector2 direction, int layerMask) where TEntity : class
//     {
//       RaycastHit2D hit = Physics2D.BoxCast(position, size, angle, direction, float.PositiveInfinity, layerMask);
//       return hit.collider != null 
//         ? _resolver.Resolve<TEntity>(hit.collider.GetInstanceID())
//         : null;
//     }
//
//     public IEnumerable<TEntity> BoxCastAll<TEntity>(Vector2 position, Vector2 size, float angle, Vector2 direction, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.BoxCastNonAlloc(position, size, angle, direction, _hits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         RaycastHit2D hit = _hits[i];
//         if (hit.collider == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.collider.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//     
//     public TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class {
//       Collider2D collider = Physics2D.OverlapPoint(worldPosition, layerMask);
//       return collider != null 
//         ? _resolver.Resolve<TEntity>(collider.GetInstanceID())
//         : null;
//     }
//
//     public IEnumerable<TEntity> OverlapPointAll<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapPointNonAlloc(worldPosition, _overlapHits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         Collider2D hit = _overlapHits[i];
//         if (hit == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//
//     public TEntity OverlapCircle<TEntity>(Vector2 worldPosition, float radius, int layerMask) where TEntity : class
//     {
//       Collider2D collider = Physics2D.OverlapCircle(worldPosition, radius, layerMask);
//       return collider != null 
//         ? _resolver.Resolve<TEntity>(collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> OverlapCircleAll<TEntity>(Vector2 worldPosition, float radius, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapCircleNonAlloc(worldPosition, radius, _overlapHits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         Collider2D hit = _overlapHits[i];
//         if (hit == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//     
//     public TEntity OverlapBox<TEntity>(Vector2 worldPosition, Vector2 size, float angle, int layerMask) where TEntity : class
//     {
//       Collider2D collider = Physics2D.OverlapBox(worldPosition, size, angle, layerMask);
//       return collider != null 
//         ? _resolver.Resolve<TEntity>(collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> OverlapBoxAll<TEntity>(Vector2 worldPosition, Vector2 size, float angle, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapBoxNonAlloc(worldPosition, size, angle, _overlapHits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         Collider2D hit = _overlapHits[i];
//         if (hit == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//     
//     public TEntity OverlapArea<TEntity>(Vector2 worldPosition, Vector2 size, int layerMask) where TEntity : class
//     {
//       Collider2D collider = Physics2D.OverlapArea(worldPosition, size, layerMask);
//       return collider != null 
//         ? _resolver.Resolve<TEntity>(collider.GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> OverlapAreaAll<TEntity>(Vector2 worldPosition, Vector2 size, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapAreaNonAlloc(worldPosition, size, _overlapHits, layerMask);
//
//       for (int i = 0; i < hitCount; i++)
//       {
//         Collider2D hit = _overlapHits[i];
//         if (hit == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//     
//     public TEntity OverlapCollider<TEntity>(Collider2D collider, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapCollider(collider, new ContactFilter2D { layerMask = layerMask },  _overlapHits);
//       return hitCount > 0 
//         ? _resolver.Resolve<TEntity>(_overlapHits[0].GetInstanceID())
//         : null;
//     }
//     
//     public IEnumerable<TEntity> OverlapColliderAll<TEntity>(Collider2D collider, int layerMask) where TEntity : class
//     {
//       int hitCount = Physics2D.OverlapCollider(collider, new ContactFilter2D { layerMask = layerMask },  _overlapHits);
//       for (int i = 0; i < hitCount; i++)
//       {
//         Collider2D hit = _overlapHits[i];
//         if (hit == null)
//           continue;
//
//         TEntity entity = _resolver.Resolve<TEntity>(hit.GetInstanceID());
//         if (entity == null)
//           continue;
//
//         yield return entity;
//       }
//     }
//   }
// }