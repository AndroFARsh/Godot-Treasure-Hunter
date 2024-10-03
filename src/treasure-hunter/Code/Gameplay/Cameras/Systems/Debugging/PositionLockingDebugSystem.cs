using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Cameras.Systems.Debugging;

#if DEBUG
public class PositionLockingDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public PositionLockingDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.PositionLocking,
        GameMatcher.Camera2D, 
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Camera2D cameraNode = entity.Camera2D;
      entity.VisualDebugger2D.RequestDrawLine(
        from: cameraNode.Position + 50 * Vector2.Left,
        to: cameraNode.Position + 50 * Vector2.Right,
        color: Colors.White,
        width: 1
      );
      entity.VisualDebugger2D.RequestDrawLine(
        from: cameraNode.Position + 50 * Vector2.Up,
        to: cameraNode.Position + 50 * Vector2.Down,
        color: Colors.White,
        width: 1
      );
    }
  }
}
#endif