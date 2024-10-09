using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Code.Gameplay.Common;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Registrars;

public partial class CeilingHitSensor2DRegistrar: EntityNodeRegistrar
{
  [Export] private RayCast2D _rayCast2DForwardFar;
  [Export] private RayCast2D _rayCast2DForward;
  [Export] private RayCast2D _rayCast2DBackward;
  [Export] private RayCast2D _rayCast2DBackwardFar;

  public override void Register(IEntity entity)
  {
    if (_rayCast2DForwardFar != null) entity.AddComponent(new CeilingHitSensorForwardFarComponent { Value = _rayCast2DForwardFar });
    if (_rayCast2DForward != null) entity.AddComponent(new CeilingHitSensorForwardComponent { Value = _rayCast2DForward });
    if (_rayCast2DBackward != null) entity.AddComponent(new CeilingHitSensorBackwardComponent { Value = _rayCast2DBackward });
    if (_rayCast2DBackwardFar != null) entity.AddComponent(new CeilingHitSensorBackwardFarComponent { Value = _rayCast2DBackwardFar });
  }

  public override void Unregister(IEntity entity)
  {
    entity.TryRemoveComponent<CeilingHitSensorForwardFarComponent>();
    entity.TryRemoveComponent<CeilingHitSensorForwardComponent>();
    entity.TryRemoveComponent<CeilingHitSensorBackwardComponent>();
    entity.TryRemoveComponent<CeilingHitSensorBackwardFarComponent>();
  } 
}