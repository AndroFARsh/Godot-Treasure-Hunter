using Code.Infrastructure.StaticData;
using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class MoveCharacterSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IStaticDataService _staticDataService;
  private readonly IGroup<GameEntity> _entities;
  private readonly GameContext _game;

  public MoveCharacterSystem(GameContext game, ITimeService timeService, IStaticDataService staticDataService)
  {
    _game = game;
    _timeService = timeService;
    _staticDataService = staticDataService;
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.CharacterBody2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      ProcessMovement(entity.CharacterBody2D);
  }

  private void ProcessMovement(CharacterBody2D body)
  {
    Vector2 velocity = body.Velocity;

    // Add the gravity.
    if (!body.IsOnFloor())
    {
      velocity += body.GetGravity() * _timeService.DeltaTime;
    }

    // Handle Jump.
    if (Input.IsActionJustPressed("Jump") && body.IsOnFloor())
    {
      velocity.Y = _staticDataService.CharacterConfig.JumpVelocity;
    }

    // Get the input direction and handle the movement/deceleration.
    // As good practice, you should replace UI actions with custom gameplay actions.
    float direction = Input.GetAxis("MoveLeft", "MoveRight");
    if (direction != 0)
      velocity.X = direction * _staticDataService.CharacterConfig.RunSpeed;
    else
      velocity.X = Mathf.MoveToward(body.Velocity.X, 0, _staticDataService.CharacterConfig.RunSpeed);

    body.Velocity = velocity;
    body.MoveAndSlide();
  }
}