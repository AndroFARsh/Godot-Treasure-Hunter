using Entitas;
using Godot;

namespace Code.Common.View.Registrars;

public abstract partial class EntityNodeRegistrar : Node, IEntityNodeRegistrar
{
  public abstract void Register(IEntity entity);

  public abstract void Unregister(IEntity entity);
}