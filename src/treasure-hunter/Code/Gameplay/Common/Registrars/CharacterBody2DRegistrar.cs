using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CharacterBody2DRegistrar : CharacterBody2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new CharacterBody2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<CharacterBody2DComponent>();
}