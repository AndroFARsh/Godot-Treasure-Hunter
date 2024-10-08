using Code.Gameplay.Character.Configs;
using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class ApplyLateralMovementSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public ApplyLateralMovementSystem(InputContext input, GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _inputs = input.GetGroup(
      InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection)
    );
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character, 
        GameMatcher.LateralVelocity,
        GameMatcher.CharacterConfig)
    );
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      CharacterConfig config = entity.CharacterConfig;
      float velocity = entity.LateralVelocity;
		  
      float targetSpeed = input.HorizontalDirection * config.RunMaxSpeed;
      float rate = Mathf.Abs(targetSpeed) > 0.01f
        ? config.RunAcceleration * (entity.isInAir ? config.InAirAccelerationScale : 1) 
        : config.RunDeceleration * (entity.isInAir ? config.InAirDecelerationScale : 1);
      
      // //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
      // if (entity.isDoConserveMomentum 
      //     && Mathf.Abs(velocity) > Mathf.Abs(targetSpeed) 
      //     && Mathf.Sign(velocity) == Mathf.Sign(targetSpeed) 
      //     && Mathf.Abs(targetSpeed) > 0.01f)
      // {
      //   //Prevent any deceleration from happening, or in other words conserve are current momentum
      //   //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
      //   accelRate = 0;
      // }
      
      //Calculate difference between current velocity and desired velocity
      float speedDiff = targetSpeed - velocity;
      
      //Calculate force along x-axis to apply to thr player
      velocity += speedDiff * rate * _timeService.DeltaTime;
      entity.ReplaceLateralVelocity(velocity);
    }
  }
}