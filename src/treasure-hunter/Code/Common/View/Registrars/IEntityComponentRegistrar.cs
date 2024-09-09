using Entitas;

namespace Code.Common.View.Registrars
{
  public interface IEntityComponentRegistrar
  {
    void Register(IEntity entity);
    void Unregister(IEntity entity);
  }
}