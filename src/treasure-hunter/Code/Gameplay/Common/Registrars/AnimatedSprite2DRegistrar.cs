using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class AnimatedSprite2DRegistrar : AnimatedSprite2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new AnimatedSprite2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<AnimatedSprite2DComponent>();
}