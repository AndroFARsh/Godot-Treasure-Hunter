using System.Collections.Generic;
using Entitas;

namespace Code.Infrastructure.Physics
{
  class ColliderToEntityRegistryResolver : IColliderToEntityRegistry, IEntityResolverFromCollider
  {
    private readonly Dictionary<ulong, IEntity> _entityByInstanceId = new();
    
    public void Register(ulong instanceId, IEntity entity) => _entityByInstanceId[instanceId] = entity;

    public void Unregister(ulong instanceId) => _entityByInstanceId.Remove(instanceId);

    public TEntity Resolve<TEntity>(ulong instanceId) where TEntity : class =>
      _entityByInstanceId.TryGetValue(instanceId, out IEntity entity)
        ? (TEntity)entity
        : null;
  }
}