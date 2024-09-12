using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class Node2DRegistrar : EntityNodeRegistrar<GameEntity>
{
  [Export] private Node2D _node;

  public override void Register(GameEntity entity)
  {
    _node ??= GetParent().FindChildOfType<Node2D>();
    if (_node != null) entity.AddNode2D(_node);
  }

  public override void Unregister(GameEntity entity)
  {
    if (entity.hasNode2D) entity.RemoveNode2D();
  }
}