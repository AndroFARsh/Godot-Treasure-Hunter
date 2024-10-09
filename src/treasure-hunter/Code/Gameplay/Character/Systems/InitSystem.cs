using Code.Gameplay.Character.Factories;
using Code.Gameplay.CharacterParticleEffects;
using Code.Gameplay.CharacterParticleEffects.Factories;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class InitSystem : IInitializeSystem
{
  private readonly ICharacterFactory _characterFactory;
  private readonly IParticleEffectFactory _particleEffectFactory;

  public InitSystem(ICharacterFactory characterFactory, IParticleEffectFactory particleEffectFactory)
  {
    _characterFactory = characterFactory;
    _particleEffectFactory = particleEffectFactory;
  }

  public void Initialize()
  {
    GameEntity character = _characterFactory.Create();
    _particleEffectFactory.Create(ParticleEffectName.Run, character.Id);
    _particleEffectFactory.Create(ParticleEffectName.Jump, character.Id);
    _particleEffectFactory.Create(ParticleEffectName.Land, character.Id);
  } 
}