using Entitas;

namespace Code.Common.View.Registrars
{
  public interface IEntityNodeRegistrar
  {
    void Register(IEntity entity);
    void Unregister(IEntity entity);
  }
}