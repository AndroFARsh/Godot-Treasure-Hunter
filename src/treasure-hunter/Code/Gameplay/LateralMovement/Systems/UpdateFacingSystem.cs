using Entitas;

namespace Code.Gameplay.LateralMovement.Systems;

public class UpdateFacingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateFacingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Facing, GameMatcher.LateralDirection));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      if (entity.LateralDirection != 0)
        entity.ReplaceFacing(entity.LateralDirection);
    }
  }
}