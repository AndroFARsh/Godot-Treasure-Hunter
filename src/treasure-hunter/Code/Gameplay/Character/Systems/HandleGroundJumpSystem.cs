using Entitas;

namespace Code.Gameplay.Character.Systems;

public class HandleGroundJumpSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public HandleGroundJumpSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.Character);
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character,
        GameMatcher.AirVelocity,
        GameMatcher.CharacterConfig)
    );
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      // if (HasJustLanded(entity))
      //   entity.isJumping = false;

      if (AllowGroundJump(input, entity)) Jump(entity);

      HandleCoyoteTime(entity);
      HandleJumpBuffer(input, entity);
    }
  }

  private static void HandleJumpBuffer(InputEntity input, GameEntity entity)
  {
    if (input.isJumpJustPressed && entity.isInAir)
      entity.ReplaceJumpBufferInputTimer(entity.CharacterConfig.JumpInputBufferTime);

    if (entity.isOnFloor && entity.hasJumpBufferInputTimer)
      Jump(entity);
  }

  private static void HandleCoyoteTime(GameEntity entity)
  {
    if (entity.isInAir && entity.isPrevFrameOnFloor && !entity.isGoingUp && !entity.isJumping)
      entity.ReplaceCoyoteTimer(entity.CharacterConfig.CoyoteTime);

    if (entity.hasCoyoteTimer && !entity.isJumping)
      entity.ReplaceAirVelocity(0);
  }

  private static bool AllowGroundJump(InputEntity input, GameEntity entity) =>
    input.isJumpJustPressed && !entity.isJumping && (entity.isOnFloor || entity.hasCoyoteTimer);

  private static bool HasJustLanded(GameEntity entity) =>
    entity.isOnFloor && !entity.isPrevFrameOnFloor && entity.isJumping;

  private static void Jump(GameEntity entity)
  {
    entity.isJumping = true;
    entity.ReplaceAirVelocity(entity.CharacterConfig.JumpVelocity);
    entity.TryRemoveComponent<CoyoteTimerComponent>();
  }
}