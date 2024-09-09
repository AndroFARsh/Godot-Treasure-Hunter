using System.Collections.Generic;
using Entitas;

namespace Code.Infrastructure.Physics
{
  class ColliderToEntityRegistryResolver : IColliderToEntityRegistry, IEntityResolverFromCollider
  {
    private readonly Dictionary<int, IEntity> _entityByInstanceId = new();
    
    public void Register(int instanceId, IEntity entity) => _entityByInstanceId[instanceId] = entity;

    public void Unregister(int instanceId) => _entityByInstanceId.Remove(instanceId);

    public TEntity Resolve<TEntity>(int instanceId) where TEntity : class =>
      _entityByInstanceId.TryGetValue(instanceId, out IEntity entity)
        ? (TEntity)entity
        : null;
  }
}