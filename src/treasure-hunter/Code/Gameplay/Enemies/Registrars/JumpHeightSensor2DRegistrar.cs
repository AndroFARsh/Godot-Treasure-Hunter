using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Registrars;

[GlobalClass]
public partial class JumpHeightSensor2DRegistrar : RayCast2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new JumpHeightSensor2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<JumpHeightSensor2DComponent>();
}