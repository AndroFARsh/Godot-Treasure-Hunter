using Code.Common.CleanUp;
using Code.Common.View;
using Code.Gameplay.Cameras;
using Code.Gameplay.Character;
using Code.Gameplay.Enemies;
using Code.Gameplay.GameViews;
using Code.Gameplay.Gravity;
using Code.Gameplay.Inputs;
using Code.Gameplay.LateralMovement;
using Code.Gameplay.VisualEffects;
using Code.Infrastructure.Systems;

namespace Code.Gameplay;

public class GameplayFeature : Feature
{
  public GameplayFeature(ISystemFactory systems)
  {
    Add(systems.Create<InputFeature>());

    Add(systems.Create<GravityFeature>());
    
    Add(systems.Create<EnemyFeature>());
    Add(systems.Create<CharacterFeature>());
    Add(systems.Create<VisualEffectFeature>());

    Add(systems.Create<LateralMovementFeature>());
    
    Add(systems.Create<CameraFeature>());
    
    Add(systems.Create<GameViewsFeature>());
    
    Add(systems.Create<ViewFeature>());
    Add(systems.Create<CleanUpFeature>());
  }
}