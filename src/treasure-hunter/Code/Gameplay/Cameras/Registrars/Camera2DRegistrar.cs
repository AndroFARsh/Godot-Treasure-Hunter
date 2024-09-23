using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Registrars;

[GlobalClass]
public partial class Camera2DRegistrar : EntityNodeRegistrar
{
  [Export] private Camera2D _camera2D;

  public override void Register(IEntity entity)
  {
    _camera2D ??= GetParent().FindChildOfType<Camera2D>();
    if (_camera2D != null) entity.AddComponent(new Camera2DComponent { Value = _camera2D });
  }

  public override void Unregister(IEntity entity) => entity.TryRemoveComponent<Camera2DComponent>();
}