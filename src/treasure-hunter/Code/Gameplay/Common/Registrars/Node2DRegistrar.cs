using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class Node2DRegistrar : EntityNodeRegistrar
{
  [Export] private Node2D _node;

  public override void Register(IEntity entity)
  {
    _node ??= GetParent().FindChildOfType<Node2D>();
    if (_node != null) entity.AddComponent(new Node2DComponent { Value = _node });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<Node2DComponent>();
}