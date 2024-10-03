using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.LateralMove.Systems;

public class UpdateLateralVelocitySystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;

  public UpdateLateralVelocitySystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.LateralDirection,
        GameMatcher.MaxSpeed,
        GameMatcher.Movable
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float velocity = entity.hasLateralVelocity ? entity.LateralVelocity : 0;
      
      float acceleration = entity.hasAcceleration ? entity.Acceleration : 1;
      float deceleration = entity.hasDeceleration ? entity.Deceleration : 1;

      float targetSpeed = entity.LateralDirection * entity.MaxSpeed;
      float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
      
      // //Increase are acceleration and maxSpeed when at the apex of their jump, makes the jump feel a bit more bouncy, responsive and natural
      // if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.Velocity.Y) < Data.JumpHangTimeThreshold)
      // {
      //   accelRate *= Data.JumpHangAccelerationMult;
      //   targetSpeed *= Data.JumpHangMaxSpeedMult;
      // }
      
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
      //
      //Calculate difference between current velocity and desired velocity
      float speedDif = targetSpeed - velocity;
      
      //Calculate force along x-axis to apply to thr player
      float newVelocity = velocity + speedDif * accelRate * _timeService.DeltaTime;
      
      entity.ReplaceLateralVelocity(newVelocity);
    }
  }
}