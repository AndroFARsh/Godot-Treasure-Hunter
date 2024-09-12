using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CharacterBody2DRegistrar : EntityNodeRegistrar<GameEntity>
{
  [Export] private CharacterBody2D _characterBody2D;

  public override void Register(GameEntity entity)
  {
    _characterBody2D ??= GetParent().FindChildOfType<CharacterBody2D>();
    if (_characterBody2D != null) entity.AddCharacterBody2D(_characterBody2D);
  }

  public override void Unregister(GameEntity entity)
  {
    if (entity.hasCharacterBody2D) entity.RemoveCharacterBody2D();
  }

  
}