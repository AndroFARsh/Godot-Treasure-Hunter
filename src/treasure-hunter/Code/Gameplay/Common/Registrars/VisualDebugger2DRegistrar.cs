using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Code.Gameplay.Common.Nodes;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class VisualDebugger2DRegistrar : VisualDebugger2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new VisualDebugger2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<VisualDebugger2DComponent>();
}