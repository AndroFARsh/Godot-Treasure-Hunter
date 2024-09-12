using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class AnimatedSprite2DRegistrar : EntityNodeRegistrar<GameEntity>
{
  [Export] private AnimatedSprite2D _animatedSprite2D;

  public override void Register(GameEntity entity)
  {
    _animatedSprite2D ??= GetParent().FindChildOfType<AnimatedSprite2D>();
    if (_animatedSprite2D != null) entity.AddAnimatedSprite2D(_animatedSprite2D);
  }

  public override void Unregister(GameEntity entity)
  {
    if (entity.hasAnimatedSprite2D) entity.RemoveAnimatedSprite2D();
  }

  
}