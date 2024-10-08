using Entitas;

namespace Code.Gameplay.Character.Systems;

public class HandleAirJumpSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public HandleAirJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.Character);
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.InAir,
        GameMatcher.Character,
        GameMatcher.AirVelocity,
        GameMatcher.CharacterConfig,
        GameMatcher.AirJumpNumber)
    );
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      entity.isJustAirJump = false;
      
      if (AllowAirJump(input, entity)) 
        Jump(entity);
    }
  }

  private static bool AllowAirJump(InputEntity input, GameEntity entity) =>
    input.isJumpJustPressed && entity.AirJumpNumber > 0 && !entity.hasCoyoteTimer;
  
  private static void Jump(GameEntity entity)
  {
    entity.ReplaceAirJumpNumber(entity.AirJumpNumber - 1);
    entity.ReplaceAirVelocity(entity.CharacterConfig.AirJumpVelocity);
    entity.isJustAirJump = true;
  }
}