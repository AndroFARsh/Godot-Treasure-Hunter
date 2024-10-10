using Code.Common.View.Registrars;
using Code.Gameplay.Character;
using Code.Gameplay.GameViews;
using Entitas;
using Godot;
using LandAnimator2D = Code.Gameplay.Common.Nodes.LandAnimator2D;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class FacingNode2DRegistrar: EntityNodeRegistrar
{
  [Export] private Node2D _node2D;
  public override void Register(IEntity entity)
  {
    if (_node2D != null) entity.AddComponent(new FacingNode2DComponent { Value = _node2D });
  }

  public override void Unregister(IEntity entity)
  {
    entity.TryRemoveComponent<FacingNode2DComponent>();
  } 
}