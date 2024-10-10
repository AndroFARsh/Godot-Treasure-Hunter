using Code.Gameplay.Enemies.Factories;
using Code.Gameplay.VisualEffects;
using Code.Gameplay.VisualEffects.Factories;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class InitSystem : IInitializeSystem
{
  private readonly IEnemyFactory _enemyFactory;
  private readonly IDustParticleEffectFactory _dustParticleEffectFactory;

  public InitSystem(IEnemyFactory enemyFactory, IDustParticleEffectFactory dustParticleEffectFactory)
  {
    _enemyFactory = enemyFactory;
    _dustParticleEffectFactory = dustParticleEffectFactory;
  }
  
  public void Initialize()
  {
    GameEntity enemyEntity = _enemyFactory.Create(EnemyName.Crubby, new Vector2(182, -10));
    _dustParticleEffectFactory.Create(DustParticleEffectName.Run, enemyEntity.Id);
    _dustParticleEffectFactory.Create(DustParticleEffectName.Jump, enemyEntity.Id);
    _dustParticleEffectFactory.Create(DustParticleEffectName.Land, enemyEntity.Id);
  }
}