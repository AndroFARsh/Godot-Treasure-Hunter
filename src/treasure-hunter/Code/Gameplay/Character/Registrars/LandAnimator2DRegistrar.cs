using Code.Common.View.Registrars;
using Code.Gameplay.Character.Nodes;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Registrars;

[GlobalClass]
public partial class LandAnimator2DRegistrar: EntityNodeRegistrar
{
  [Export] private LandAnimator2D _landAnimator2D;
  public override void Register(IEntity entity)
  {
    if (_landAnimator2D != null) entity.AddComponent(new LandAnimator2DComponent { Value = _landAnimator2D });
  }

  public override void Unregister(IEntity entity)
  {
    entity.TryRemoveComponent<CeilingHitSensorForwardFarComponent>();
  } 
}