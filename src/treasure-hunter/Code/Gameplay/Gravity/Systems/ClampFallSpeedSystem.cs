using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class ClampFallSpeedSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public ClampFallSpeedSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.FallMaxSpeed,
      GameMatcher.AirVelocity
    ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      if (entity.AirVelocity > entity.FallMaxSpeed) 
        entity.ReplaceAirVelocity(entity.FallMaxSpeed);
    }
  }
}