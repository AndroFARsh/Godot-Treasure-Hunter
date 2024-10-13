using Entitas;

namespace Code.Infrastructure.Physics;

public interface IColliderToEntityRegistry
{
  void Register(ulong instanceId, IEntity entity);
    
  void Unregister(ulong instanceId);
}