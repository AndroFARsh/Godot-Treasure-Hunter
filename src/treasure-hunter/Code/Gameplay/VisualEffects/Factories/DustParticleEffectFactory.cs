using System;
using Code.Common.Extensions;
using Code.Infrastructure.EntityFactories;
using Code.StaticData;
using Godot;

namespace Code.Gameplay.VisualEffects.Factories;

public class DustParticleEffectFactory : IDustParticleEffectFactory
{
  private readonly IEntityFactory _entityFactory;
  private readonly IStaticDataService _staticDataService;

  public DustParticleEffectFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
  {
    _entityFactory = entityFactory;
    _staticDataService = staticDataService;
  }

  public GameEntity Create(DustParticleEffectName name, ulong targetId)
  {
    PackedScene prefab = _staticDataService.GetParticleEffectPrefab(name);
    GameEntity entity = _entityFactory.CreateEntity<GameEntity>()
      .AddDustParticleEffect(name)
      .AddViewPrefab(prefab)
      .AddTargetId(targetId);

    switch (name)
    {
      case DustParticleEffectName.Run:
        entity
          .With(e => e.isRunDustParticleEffect = true)
          .AddFacing(0);
        break;
      case DustParticleEffectName.Jump:
        entity.With(e => e.isJumpDustParticleEffect = true);
        break;
      case DustParticleEffectName.Land:
        entity.With(e => e.isLandDustParticleEffect = true);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(name), name, null);
    }  
    
    return entity;
  }
}