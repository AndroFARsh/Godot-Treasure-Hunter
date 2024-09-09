using Entitas;

namespace Code.Infrastructure.Physics
{
  public interface IColliderToEntityRegistry
  {
    void Register(int instanceId, IEntity entity);
    
    void Unregister(int instanceId);
  }
}