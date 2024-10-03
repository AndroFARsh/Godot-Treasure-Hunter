using Code.Gameplay.Character.Configs;
using Entitas;

namespace Code.Gameplay.Character.Jump.Systems;

public class InterruptJumpSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public InterruptJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character).NoneOf(InputMatcher.JumpPressed));
    _characters = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.CharacterConfig,
      GameMatcher.Air
    ));
  }
  public void Execute()
  {
    foreach (InputEntity _ in _inputs)
    foreach (GameEntity character in _characters)
    {
      CharacterConfig config = character.CharacterConfig;
      character.ReplaceGravityScale(config.JumpCutGravityMult);
    }
  }
}