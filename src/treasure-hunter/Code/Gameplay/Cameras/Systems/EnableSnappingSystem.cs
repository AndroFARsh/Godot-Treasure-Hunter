using Code.Gameplay.Cameras.Configs;
using Entitas;

namespace Code.Gameplay.Cameras.Systems;

public class EnableSnappingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public EnableSnappingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.SnappingType));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.isPositionSnapping = entity.SnappingType == SnappingType.PositionSnapping;
      entity.isPlatformSnapping = entity.SnappingType == SnappingType.PlatformSnapping;
    }
  }
}