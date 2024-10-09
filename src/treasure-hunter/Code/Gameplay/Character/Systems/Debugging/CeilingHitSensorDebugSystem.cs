using Code.Gameplay.Common.Nodes;
using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.Systems.Debugging;

#if DEBUG

public class CeilingHitSensorDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public CeilingHitSensorDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.VisualDebugger2D,
        GameMatcher.CeilingHitSensorForwardFar,
        GameMatcher.CeilingHitSensorForward,
        GameMatcher.CeilingHitSensorBackward,
        GameMatcher.CeilingHitSensorBackwardFar));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      DrawRayCast2D(entity.VisualDebugger2D, entity.CeilingHitSensorForwardFar);
      DrawRayCast2D(entity.VisualDebugger2D, entity.CeilingHitSensorForward);
      DrawRayCast2D(entity.VisualDebugger2D, entity.CeilingHitSensorBackward);
      DrawRayCast2D(entity.VisualDebugger2D, entity.CeilingHitSensorBackwardFar);
    }
  }

  private void DrawRayCast2D(VisualDebugger2D debugger2D, RayCast2D rayCast2D)
  {
    debugger2D.RequestDrawLine(
      from: rayCast2D.GlobalPosition,
      to: rayCast2D.GlobalPosition + rayCast2D.TargetPosition,
      color: rayCast2D.IsColliding() ? Colors.Red : Colors.Green,
      width: 1
    );
  }
}
#endif