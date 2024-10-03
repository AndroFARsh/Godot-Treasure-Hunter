using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Cameras.Systems.Debugging;

#if DEBUG
public class HPositionLockingDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public HPositionLockingDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.HPositionLocking,
        GameMatcher.Camera2D,
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Camera2D camera2D = entity.Camera2D;
      entity.VisualDebugger2D.RequestDrawLine(
        from: new Vector2(camera2D.Position.X, camera2D.LimitTop),
        to: new Vector2(camera2D.Position.X, camera2D.LimitBottom),
        color: Colors.White,
        width: 1
      );
    }
  }
}
#endif