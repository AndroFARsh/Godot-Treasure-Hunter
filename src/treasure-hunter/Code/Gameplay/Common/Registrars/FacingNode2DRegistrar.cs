using Code.Common.View.Registrars;
using Code.Gameplay.GameViews;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class FacingNode2DRegistrar: Node2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new FacingNode2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<FacingNode2DComponent>();
}