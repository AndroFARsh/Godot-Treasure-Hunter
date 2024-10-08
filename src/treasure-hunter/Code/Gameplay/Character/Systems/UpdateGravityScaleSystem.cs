using Entitas;

namespace Code.Gameplay.Character.Systems;

public class UpdateGravityScaleSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public UpdateGravityScaleSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.Character);
    _entities = game.GetGroup(
      GameMatcher.AllOf(
          GameMatcher.CharacterConfig, 
          GameMatcher.GravityScale)
      );
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      float gravityScale = 1f;
      if (entity.isInAir)
      {
        if (ShouldCutJump(input, entity)) 
          gravityScale = entity.CharacterConfig.JumpCutGravityScale;
        else if (ShouldAirHang(entity))
          gravityScale = ResolveApexHangGravityScale(entity);
        else if (ShouldFall(entity)) 
          gravityScale = entity.CharacterConfig.FallGravityScale;
      }

      entity.ReplaceGravityScale(gravityScale);
    }
  }

  private static float ResolveApexHangGravityScale(GameEntity entity)
  {
    if (!entity.hasJumpApexHangTimer) 
      entity.AddJumpApexHangTimer(entity.CharacterConfig.JumpApexHangTime);
    
    return entity.CharacterConfig.JumpHangGravityScale;
  }

  private static bool ShouldFall(GameEntity entity) =>
    entity.CharacterConfig.JumpCutGravityScaleFeature &&
    entity.isFalling;

  private static bool ShouldCutJump(InputEntity input, GameEntity entity) =>
    entity.CharacterConfig.JumpCutGravityScaleFeature && 
    !input.isJumpPressed && 
    entity.isGoingUp;

  private static bool ShouldAirHang(GameEntity entity) => 
    entity.CharacterConfig.JumpHangGravityScaleFeature &&
    entity.isPrevFrameInAir &&
    ((entity.isPrevFrameGoingUp && entity.isFalling) || entity.hasJumpApexHangTimer);
}