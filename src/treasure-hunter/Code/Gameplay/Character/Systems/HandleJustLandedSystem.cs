using Entitas;

namespace Code.Gameplay.Character.Systems;

public class HandleJustLandedSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public HandleJustLandedSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character,
        GameMatcher.OnFloor,
        GameMatcher.PrevFrameInAir,
        GameMatcher.Jumping)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.isJumping = false;
  }
}