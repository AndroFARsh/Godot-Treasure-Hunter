using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class UpdateCharacterFacingSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public UpdateCharacterFacingSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection));
    _characters = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character, 
        GameMatcher.Facing
      ));
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity character in _characters)
    {
      float horizontalDirection = input.HorizontalDirection;
      if (Mathf.Abs(horizontalDirection) > float.Epsilon)
        character.ReplaceFacing(Mathf.Sign(horizontalDirection));
    }
  }
}