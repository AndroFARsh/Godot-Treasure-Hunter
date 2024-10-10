using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class MergeVelocitySystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public MergeVelocitySystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
          GameMatcher.LateralVelocity, 
          GameMatcher.AirVelocity)
      );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.ReplaceVelocity(new Vector2(entity.LateralVelocity, entity.AirVelocity));
  }
}