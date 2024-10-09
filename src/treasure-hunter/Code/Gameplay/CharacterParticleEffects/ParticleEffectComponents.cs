using Entitas;

namespace Code.Gameplay.CharacterParticleEffects;

[Game] public class ParticleEffectComponent : IComponent { public ParticleEffectName Value; }

[Game] public class RunParticleEffectComponent : IComponent { }
[Game] public class JumpParticleEffectComponent : IComponent { }
[Game] public class LandParticleEffectComponent : IComponent { }