using Code.Gameplay.Character.Configs;
using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.LateralMovement.Systems;

public class ApplyLateralMovementSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;
  
  public ApplyLateralMovementSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.LateralVelocity,
        GameMatcher.LateralMaxSpeed,
        GameMatcher.LateralDirection)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float velocity = entity.LateralVelocity;
		  
      float targetSpeed = entity.LateralDirection * entity.LateralMaxSpeed;
      float rate = Mathf.Abs(targetSpeed) > 0.01f
        ? entity.hasAcceleration ? entity.Acceleration : 1 
        : entity.hasDeceleration ? entity.Deceleration : 1;
      
      //Calculate difference between current velocity and desired velocity
      float speedDiff = targetSpeed - velocity;
      
      //Calculate force along x-axis to apply to thr player
      velocity += speedDiff * rate * _timeService.DeltaTime;
      entity.ReplaceLateralVelocity(velocity);
    }
  }
}