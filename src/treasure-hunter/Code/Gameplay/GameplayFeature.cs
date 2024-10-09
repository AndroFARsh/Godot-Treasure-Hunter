using Code.Common.CleanUp;
using Code.Common.View;
using Code.Gameplay.Cameras;
using Code.Gameplay.Character;
using Code.Gameplay.CharacterParticleEffects;
using Code.Gameplay.GameViews;
using Code.Gameplay.Inputs;
using Code.Infrastructure.Systems;

namespace Code.Gameplay;

public class GameplayFeature : Feature
{
  public GameplayFeature(ISystemFactory systems)
  {
    Add(systems.Create<InputFeature>());
    
    Add(systems.Create<CharacterFeature>());
    Add(systems.Create<ParticleEffectFeature>());
    
    Add(systems.Create<CameraFeature>());
    
    Add(systems.Create<GameViewsFeature>());
    
    Add(systems.Create<ViewFeature>());
    Add(systems.Create<CleanUpFeature>());
  }
}