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
    _entities = game.GetGroup(
      GameMatcher.AllOf(
          GameMatcher.CharacterConfig, 
          GameMatcher.GravityScale,
          GameMatcher.AirVelocity,
          GameMatcher.InAir)
      );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float velocity = entity.AirVelocity + entity.CharacterConfig.GravityStrength * entity.GravityScale * _timeService.DeltaTime;
      if (velocity > entity.CharacterConfig.FallMaxSpeed)
        velocity = entity.CharacterConfig.FallMaxSpeed;
      
      entity.ReplaceAirVelocity(velocity);
    }
  }
}