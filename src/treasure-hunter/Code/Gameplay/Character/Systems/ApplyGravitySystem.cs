using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class ApplyGravitySystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;

  public ApplyGravitySystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Velocity,
      GameMatcher.Gravity,
      GameMatcher.Air,
      GameMatcher.ApplyGravity
    ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.ReplaceVelocity(entity.Velocity + entity.Gravity * _timeService.DeltaTime);
  }
}