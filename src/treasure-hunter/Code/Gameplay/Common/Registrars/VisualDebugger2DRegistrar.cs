using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Code.Gameplay.Common.Nodes;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class VisualDebugger2DRegistrar : EntityNodeRegistrar
{
  [Export] private VisualDebugger2D _visualDebugger2D;

  public override void Register(IEntity entity)
  {
    _visualDebugger2D ??= GetParent().FindChildOfType<VisualDebugger2D>();
    if (_visualDebugger2D != null) entity.AddComponent(new VisualDebugger2DComponent { Value = _visualDebugger2D });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<VisualDebugger2DComponent>();
}