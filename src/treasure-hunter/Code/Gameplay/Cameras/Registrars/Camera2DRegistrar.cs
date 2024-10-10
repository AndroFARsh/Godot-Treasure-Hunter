using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Registrars;

[GlobalClass]
public partial class Camera2DRegistrar : Camera2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new Camera2DComponent { Value = this });

  public void Unregister(IEntity entity) => entity.TryRemoveComponent<Camera2DComponent>();
}