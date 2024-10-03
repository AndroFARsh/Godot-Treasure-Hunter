using Code.Gameplay.Character.Configs;
using Entitas;

namespace Code.Gameplay.Character.Jump.Systems;

public class UpdateFallGravityScaleSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _characters;

  public UpdateFallGravityScaleSystem(GameContext game)
  {
    _characters = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character,
      GameMatcher.CharacterConfig,
      GameMatcher.Air,
      GameMatcher.Falling
    ));
  }
  public void Execute()
  {
    foreach (GameEntity character in _characters)
    {
       CharacterConfig config = character.CharacterConfig;
      character.ReplaceGravityScale(config.FallGravityMult);
    }
  }
}