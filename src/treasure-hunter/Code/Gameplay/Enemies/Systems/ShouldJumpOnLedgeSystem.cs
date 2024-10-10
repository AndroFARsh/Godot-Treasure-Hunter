using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class ShouldJumpOnLedgeSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
 
  public ShouldJumpOnLedgeSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Enemy,
        GameMatcher.WallSensor2D,
        GameMatcher.JumpSensor2D,
        GameMatcher.LateralDirection,
        GameMatcher.JumpVelocity,
        GameMatcher.OnFloor
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Vector2 moveDirection = Vector2.Right * entity.LateralDirection;
      RayCast2D jumpSensor = entity.JumpSensor2D;
      RayCast2D wallSensor = entity.WallSensor2D;
      if (!jumpSensor.IsColliding() &&
          wallSensor.IsColliding() && 
          wallSensor.GetCollisionNormal().Dot(moveDirection) < 0) 
      {
        entity.ReplaceAirVelocity(entity.JumpVelocity);
      }
    }
  }
}