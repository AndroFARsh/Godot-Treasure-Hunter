using Entitas;

namespace Code.Gameplay.VisualEffects;

[Game] public class DustParticleEffectComponent : IComponent { public DustParticleEffectName Value; }
[Game] public class RunDustParticleEffectComponent : IComponent { }
[Game] public class JumpDustParticleEffectComponent : IComponent { }
[Game] public class LandDustParticleEffectComponent : IComponent { }