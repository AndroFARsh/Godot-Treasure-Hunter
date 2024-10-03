using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Cameras.Systems.Debugging;

#if DEBUG
public class CameraWindowDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public CameraWindowDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.CameraWindow,
        GameMatcher.Camera2D, 
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Rect2 cameraRect = entity.CameraWindowRect;
      Camera2D cameraNode = entity.Camera2D;
      cameraRect.Position = cameraNode.Position + cameraRect.Position;
      entity.VisualDebugger2D.RequestDrawRect(
        rect: cameraRect,
        color: Colors.White,
        width: 1
      );
    }
  }
}
#endif