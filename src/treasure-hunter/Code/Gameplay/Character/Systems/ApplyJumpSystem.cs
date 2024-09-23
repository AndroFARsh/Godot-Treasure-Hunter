using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class ApplyJumpSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _characters;

  public ApplyJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.JumpJustPressed));
    _characters = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.Velocity,
      GameMatcher.JumpForce
      ).AnyOf(GameMatcher.Grounded, GameMatcher.CoyoteTimer));
  }
  public void Execute()
  {
    foreach (InputEntity _ in _inputs)
    foreach (GameEntity character in _characters)
    {
      Vector2 velocity = character.Velocity;
      velocity.Y = character.JumpForce;
      character.ReplaceVelocity(velocity);
    }
  }
}