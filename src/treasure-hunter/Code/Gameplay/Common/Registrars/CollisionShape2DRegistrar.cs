using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CollisionShape2DRegistrar : EntityNodeRegistrar
{
  [Export] private CollisionShape2D _collisionShape2D;

  public override void Register(IEntity entity)
  {
    _collisionShape2D ??= GetParent().FindChildOfType<CollisionShape2D>();
    if (_collisionShape2D != null) entity. AddComponent(new CollisionShape2DComponent { Value = _collisionShape2D });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<CollisionShape2DComponent>();
}