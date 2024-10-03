using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Gravity.Systems;

public class GravitySystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;

  public GravitySystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Gravity,
      GameMatcher.Air,
      GameMatcher.ApplyGravity
    ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float airVelocity = (entity.hasAirVelocity ? entity.AirVelocity : 0f);
      float gravityScale = (entity.hasGravityScale ? entity.GravityScale : 1f);
      airVelocity += entity.Gravity * gravityScale * _timeService.DeltaTime;
      entity.ReplaceAirVelocity(airVelocity);
    }
  }
}