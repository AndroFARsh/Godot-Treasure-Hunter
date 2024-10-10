namespace Code.Gameplay.VisualEffects.Factories;

public interface IDustParticleEffectFactory
{
  GameEntity Create(DustParticleEffectName name, ulong targetId);
}