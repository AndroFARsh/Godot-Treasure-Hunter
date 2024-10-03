using Entitas;

namespace Code.Gameplay.Character.Jump.Systems;

public class CheckIsGroundJumpSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _inputs;
  private readonly IGroup<GameEntity> _groundedOrCoyote;
  private readonly IGroup<GameEntity> _buffered;

  public CheckIsGroundJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.JumpJustPressed));
    _groundedOrCoyote = game.GetGroup(
      GameMatcher
        .AllOf(GameMatcher.Character)
        .AnyOf(GameMatcher.Grounded, GameMatcher.CoyoteTimer));
    
    _buffered = game.GetGroup(
      GameMatcher
        .AllOf(GameMatcher.Character, GameMatcher.JumpInputBufferTimer, GameMatcher.Grounded));
  }
  public void Execute()
  {
    foreach (InputEntity _ in _inputs)
    foreach (GameEntity character in _groundedOrCoyote)
      character.isPerformGroundJump = true;
    
    foreach (GameEntity character in _buffered)
      character.isPerformGroundJump = true;

  }
}