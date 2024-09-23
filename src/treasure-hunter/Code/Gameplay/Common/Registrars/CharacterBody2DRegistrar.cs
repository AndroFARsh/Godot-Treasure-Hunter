using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CharacterBody2DRegistrar : EntityNodeRegistrar
{
  [Export] private CharacterBody2D _characterBody2D;

  public override void Register(IEntity entity)
  {
    _characterBody2D ??= GetParent().FindChildOfType<CharacterBody2D>();
    if (_characterBody2D != null) entity.AddComponent(new CharacterBody2DComponent { Value = _characterBody2D });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<CharacterBody2DComponent>();
}