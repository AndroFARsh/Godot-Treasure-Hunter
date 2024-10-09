using Code.Gameplay.CharacterParticleEffects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.CharacterParticleEffects;

public sealed class ParticleEffectFeature : Feature
{
  public ParticleEffectFeature(ISystemFactory systems)
  {
    Add(systems.Create<HandleRunParticleEffectSystem>());
    Add(systems.Create<HandleJumpParticleEffectSystem>());
    Add(systems.Create<HandleLandParticleEffectSystem>());
    Add(systems.Create<HideParticleEffectOnAnimationEndSystem>());
  }
}