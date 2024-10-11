using Code.Gameplay.Common.Nodes;
using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Enemies.Systems.Debugging;

#if DEBUG

public class SensorVisualDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _wallEntities;
  private readonly IGroup<GameEntity> _ledgeEntities;
  private readonly IGroup<GameEntity> _jumpEntities;

  public SensorVisualDebugSystem(GameContext game)
  {
    _wallEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.VisualDebugger2D,
        GameMatcher.ForwardSensor2D));
    
    _ledgeEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.VisualDebugger2D,
        GameMatcher.LedgeSensor2D));
    
    _jumpEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.VisualDebugger2D,
        GameMatcher.JumpHeightSensor2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _wallEntities)
      DrawRayCast2D(entity.VisualDebugger2D, entity.ForwardSensor2D);
    
    foreach (GameEntity entity in _ledgeEntities)
      DrawRayCast2D(entity.VisualDebugger2D, entity.LedgeSensor2D);
    
    foreach (GameEntity entity in _jumpEntities)
      DrawRayCast2D(entity.VisualDebugger2D, entity.JumpHeightSensor2D);
  }

  private void DrawRayCast2D(VisualDebugger2D debugger2D, RayCast2D rayCast2D)
  {
    
    debugger2D.RequestDrawLine(
      from: rayCast2D.GlobalPosition,
      to: rayCast2D.GlobalPosition + rayCast2D.GlobalTransform.BasisXform(rayCast2D.TargetPosition),
      color: rayCast2D.IsColliding() ? Colors.Red : Colors.Green,
      width: 1
    );
  }
}
#endif