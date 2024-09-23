using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Godot;

namespace Code.Gameplay.Cameras.Registrars;

[GlobalClass]
public partial class Camera2DRegistrar : EntityNodeRegistrar<GameEntity>
{
  [Export] private Camera2D _camera2D;

  public override void Register(GameEntity entity)
  {
    _camera2D ??= GetParent().FindChildOfType<Camera2D>();
    if (_camera2D != null) entity.AddCamera2D(_camera2D);
  }

  public override void Unregister(GameEntity entity)
  {
    if (entity.hasCamera2D) entity.RemoveCamera2D();
  }

  
}