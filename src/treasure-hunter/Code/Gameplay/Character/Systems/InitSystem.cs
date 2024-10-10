using Code.Gameplay.Character.Factories;
using Code.Gameplay.VisualEffects;
using Code.Gameplay.VisualEffects.Factories;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class InitSystem : IInitializeSystem
{
  private readonly ICharacterFactory _characterFactory;
  private readonly IDustParticleEffectFactory _dustParticleEffectFactory;

  public InitSystem(ICharacterFactory characterFactory, IDustParticleEffectFactory dustParticleEffectFactory)
  {
    _characterFactory = characterFactory;
    _dustParticleEffectFactory = dustParticleEffectFactory;
  }

  public void Initialize()
  {
    GameEntity character = _characterFactory.Create();
    _dustParticleEffectFactory.Create(DustParticleEffectName.Run, character.Id);
    _dustParticleEffectFactory.Create(DustParticleEffectName.Jump, character.Id);
    _dustParticleEffectFactory.Create(DustParticleEffectName.Land, character.Id);
  } 
}