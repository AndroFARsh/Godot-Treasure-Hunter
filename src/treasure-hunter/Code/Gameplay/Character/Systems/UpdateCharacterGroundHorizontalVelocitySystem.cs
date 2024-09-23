using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class UpdateCharacterGroundHorizontalVelocitySystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public UpdateCharacterGroundHorizontalVelocitySystem(
    InputContext input,
    GameContext game,
    ITimeService timeService)
  {
    _timeService = timeService;

    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection));
    _characters = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character,
        GameMatcher.Velocity,
 //       GameMatcher.Grounded,
        GameMatcher.GroundAcceleration,
        GameMatcher.GroundDeceleration,
        GameMatcher.GroundMaxRunSpeed
      ));
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity character in _characters)
    {
      Vector2 newVelocity = NewVelocity(
        character.Velocity,
        input.HorizontalDirection,
        character.GroundAcceleration,
        character.GroundDeceleration,
        character.GroundMaxRunSpeed
      );
      character.ReplaceVelocity(newVelocity);
    }
  }

  private Vector2 NewVelocity(
    Vector2 velocity,
    float inputDirection,
    float acceleration,
    float deceleration,
    float maxSpeed
  )
  {
    float velocityMagnitude = Mathf.Abs(velocity.X);
    int velocityDirection = Mathf.Sign(velocity.X);
    int direction = Mathf.Sign(inputDirection);

    // check if we need decelerate:
    // 1) is character in move (|velocity| > 0) 
    // 2) is input direction 0 or in opposite direction to current movement
    if (velocityMagnitude > float.Epsilon && (direction == 0 || velocityDirection != direction))
    {
      velocity.X = velocityDirection * Mathf.Clamp(
        value: velocityMagnitude - deceleration * _timeService.DeltaTime,
        min: 0,
        max: maxSpeed
      );
    }
    // check if we need accelerate:
    // 1) is input direction exist (|direction| > 0)
    // 2) is character not moving or accelerating (|velocity| < MaxSpeed)
    // 3) is input direction and character move in same way
    else if (direction != 0)
    {
      velocity.X = Mathf.Sign(direction) * Mathf.Clamp(
        value: velocityMagnitude + acceleration * _timeService.DeltaTime,
        min: 0,
        max: maxSpeed
      );
    }

    return velocity;
  }
}