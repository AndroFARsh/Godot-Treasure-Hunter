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
        GameMatcher.CharacterConfig,
        GameMatcher.OnFloor,
        GameMatcher.PrevFrameInAir)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.isGroundJumping = false;
      entity.ReplaceAirJumpNumber(entity.CharacterConfig.AirJumpNumber);
    }
  }
}