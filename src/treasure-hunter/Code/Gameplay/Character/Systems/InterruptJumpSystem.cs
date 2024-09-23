using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class InterruptJumpSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public InterruptJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character).NoneOf(InputMatcher.JumpPressed));
    _characters = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.Velocity,
      GameMatcher.Air,
      GameMatcher.JumpForce
    ));
  }
  public void Execute()
  {
    foreach (InputEntity _ in _inputs)
    foreach (GameEntity character in _characters)
    {
      Vector2 velocity = character.Velocity;
      if (velocity.Y < 0) velocity.Y /= 2;
      character.ReplaceVelocity(velocity);
    }
  }
}