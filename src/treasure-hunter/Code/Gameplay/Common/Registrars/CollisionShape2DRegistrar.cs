using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CollisionShape2DRegistrar : CollisionShape2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity. AddComponent(new CollisionShape2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<CollisionShape2DComponent>();
}