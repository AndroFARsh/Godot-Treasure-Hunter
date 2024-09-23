using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class AnimatedSprite2DRegistrar : EntityNodeRegistrar
{
  [Export] private AnimatedSprite2D _animatedSprite2D;

  public override void Register(IEntity entity)
  {
    _animatedSprite2D ??= GetParent().FindChildOfType<AnimatedSprite2D>();
    if (_animatedSprite2D != null) entity.AddComponent(new AnimatedSprite2DComponent { Value = _animatedSprite2D });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<AnimatedSprite2DComponent>();
}