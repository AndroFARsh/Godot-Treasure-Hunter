using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Cameras.Systems.Debugging;

#if DEBUG
public class PositionSnappingDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public PositionSnappingDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.CameraWindow,
        GameMatcher.PositionSnapping,
        GameMatcher.Camera2D,
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Camera2D cameraNode = entity.Camera2D;
      entity.VisualDebugger2D.RequestDrawLine(
        from: cameraNode.Position + 25 * Vector2.Left,
        to: cameraNode.Position + 25 * Vector2.Right,
        color: Colors.White,
        width: 2
      );
      entity.VisualDebugger2D.RequestDrawLine(
        from: cameraNode.Position + 25 * Vector2.Up,
        to: cameraNode.Position + 25 * Vector2.Down,
        color: Colors.White,
        width: 2
      );
    }
  }
}
#endif