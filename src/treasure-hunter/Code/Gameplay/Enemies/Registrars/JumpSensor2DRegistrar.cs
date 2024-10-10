using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Registrars;

[GlobalClass]
public partial class JumpSensor2DRegistrar : EntityNodeRegistrar
{
  [Export] private RayCast2D _reyCast;

  public override void Register(IEntity entity)
  {
    if (_reyCast != null) entity.AddComponent(new JumpSensor2DComponent { Value = _reyCast });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<JumpSensor2DComponent>();
}