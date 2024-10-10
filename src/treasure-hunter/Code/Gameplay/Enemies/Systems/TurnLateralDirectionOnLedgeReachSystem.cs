using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class TurnLateralDirectionOnLedgeReachSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
 
  public TurnLateralDirectionOnLedgeReachSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Enemy,
        GameMatcher.LedgeSensor2D,
        GameMatcher.LateralDirection,
        GameMatcher.TurnOnLedgeReach,
        GameMatcher.OnFloor
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      RayCast2D sensor = entity.LedgeSensor2D;
      if (!sensor.IsColliding()) 
        entity.ReplaceLateralDirection(-entity.LateralDirection);
    }
  }
}