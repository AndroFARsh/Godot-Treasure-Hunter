using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class UpdateCharacterViewSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _characters;

  public UpdateCharacterViewSystem(GameContext game)
  {
    _characters = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character, 
        GameMatcher.Velocity,
        GameMatcher.CharacterBody2D
      ));
  }

  public void Execute()
  {
    foreach (GameEntity character in _characters)
    {
      character.CharacterBody2D.Velocity = character.Velocity;
      character.CharacterBody2D.MoveAndSlide();
    }
  }
}