using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class CleanupGravityScaleSystem : ICleanupSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();

  public CleanupGravityScaleSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Grounded,
      GameMatcher.GravityScale
    ));
  }
  
  public void Cleanup()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
      entity.RemoveGravityScale();
  }
}