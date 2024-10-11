using Code.StaticData;
using Entitas;

namespace Code.Gameplay.VisualEffects.Systems;

public class HandleJustLandedSquashEffectSystem : IExecuteSystem
{
  private readonly IStaticDataService _staticDataService;
  private readonly IGroup<GameEntity> _entities;

  public HandleJustLandedSquashEffectSystem(GameContext game, IStaticDataService staticDataService)
  {
    _staticDataService = staticDataService;
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.LandEffectAnimator2D,
        GameMatcher.OnFloor,
        GameMatcher.PrevFrameInAir)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.LandEffectAnimator2D.Play(
        _staticDataService.VisualEffectConfig.LandSquashScaleFactor, 
        _staticDataService.VisualEffectConfig.LandSquashDuration
      );
    }
  }
}