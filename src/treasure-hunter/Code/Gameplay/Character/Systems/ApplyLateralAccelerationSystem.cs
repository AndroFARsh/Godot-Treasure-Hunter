using Code.Gameplay.Character.Configs;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class ApplyLateralAccelerationSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public ApplyLateralAccelerationSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Character, GameMatcher.CharacterConfig));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      CharacterConfig config = entity.CharacterConfig;
      
      entity.ReplaceAcceleration(config.RunAcceleration * (entity.isInAir ? config.InAirAccelerationScale : 1));
      entity.ReplaceDeceleration(config.RunDeceleration * (entity.isInAir ? config.InAirDecelerationScale : 1));
    }
  }
}