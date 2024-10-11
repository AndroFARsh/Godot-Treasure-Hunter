using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Registrars;

[GlobalClass]
public partial class ForwardSensor2DRegistrar : RayCast2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new ForwardSensor2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<ForwardSensor2DComponent>();
}