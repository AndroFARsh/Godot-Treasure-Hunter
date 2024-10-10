using Code.Gameplay.VisualEffects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.VisualEffects;

public sealed class VisualEffectFeature : Feature
{
  public VisualEffectFeature(ISystemFactory systems)
  {
    Add(systems.Create<HandleRunParticleEffectSystem>());
    Add(systems.Create<HandleJumpParticleEffectSystem>());
    Add(systems.Create<HandleLandParticleEffectSystem>());
    Add(systems.Create<HideParticleEffectOnAnimationEndSystem>());
    Add(systems.Create<HandleJustLandedSquashEffectSystem>());
  }
}