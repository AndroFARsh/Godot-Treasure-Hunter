using Entitas;

namespace Code.Gameplay.Character.Lateral.Systems;

public class InputToHorizontalDirectionSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public InputToHorizontalDirectionSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection));
    _characters = game.GetGroup(GameMatcher.Character);
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity character in _characters)
      character.ReplaceLateralDirection(input.HorizontalDirection);
  }
}