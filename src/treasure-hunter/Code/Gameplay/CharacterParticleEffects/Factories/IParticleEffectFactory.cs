namespace Code.Gameplay.CharacterParticleEffects.Factories;

public interface IParticleEffectFactory
{
  GameEntity Create(ParticleEffectName name, ulong targetId);
}