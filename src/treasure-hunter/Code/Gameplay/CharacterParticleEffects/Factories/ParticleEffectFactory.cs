using System;
using Code.Common.Extensions;
using Code.Infrastructure.EntityFactories;
using Code.StaticData;
using Godot;

namespace Code.Gameplay.CharacterParticleEffects.Factories;

public class ParticleEffectFactory : IParticleEffectFactory
{
  private readonly IEntityFactory _entityFactory;
  private readonly IStaticDataService _staticDataService;

  public ParticleEffectFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
  {
    _entityFactory = entityFactory;
    _staticDataService = staticDataService;
  }

  public GameEntity Create(ParticleEffectName name, ulong targetId)
  {
    PackedScene prefab = _staticDataService.GetParticleEffectPrefab(name);
    GameEntity entity = _entityFactory.CreateEntity<GameEntity>()
      .AddParticleEffect(name)
      .AddViewPrefab(prefab)
      .AddTargetId(targetId);

    switch (name)
    {
      case ParticleEffectName.Run:
        entity
          .With(e => e.isRunParticleEffect = true)
          .AddFacingFlip(false);
        break;
      case ParticleEffectName.Jump:
        entity.With(e => e.isJumpParticleEffect = true);
        break;
      case ParticleEffectName.Land:
        entity.With(e => e.isLandParticleEffect = true);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(name), name, null);
    }  
    
    return entity;
  }
}