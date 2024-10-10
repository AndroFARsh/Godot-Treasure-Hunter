using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class ApplyGravitySystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;

  public ApplyGravitySystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.AllOf(
     // GameMatcher.ApplyGravity,
      GameMatcher.GravityStrength,
      GameMatcher.GravityScale,
      GameMatcher.AirVelocity
    ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float velocity = entity.AirVelocity + entity.GravityStrength * entity.GravityScale * _timeService.DeltaTime;
      entity.ReplaceAirVelocity(velocity);
    }
  }
}