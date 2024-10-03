using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class MergeVelocitySystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public MergeVelocitySystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher
        .AllOf(GameMatcher.Velocity)
        .AnyOf(GameMatcher.LateralVelocity, GameMatcher.AirVelocity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Vector2 velocity = new(
        entity.hasLateralVelocity ? entity.LateralVelocity : 0,
        entity.hasAirVelocity ? entity.AirVelocity : 0
      );
      entity.ReplaceVelocity(velocity);
    }
  }
}