using Code.Common.Extensions;
using Code.Gameplay.Character.Configs;
using Code.Infrastructure.EntityFactories;
using Code.StaticData;
using Godot;

namespace Code.Gameplay.Character.Factories;

public class CharacterFactory : ICharacterFactory
{
  private readonly IEntityFactory _entityFactory;
  private readonly IStaticDataService _staticDataService;

  public CharacterFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
  {
    _entityFactory = entityFactory;
    _staticDataService = staticDataService;
  }
  
  public GameEntity Create()
  {
    CharacterConfig config = _staticDataService.CharacterConfig;
    GameEntity characterEntity = _entityFactory.CreateEntity<GameEntity>()
        .AddViewPrefab(config.Prefab)
        .AddFacing(1)
        .AddCharacterConfig(config)
        .With(e => e.isApplyGravity = true)
        .AddGravityStrength(config.GravityStrength)
        .AddGravityScale(1)
        .AddFallMaxSpeed(config.FallMaxSpeed)
        .AddAirVelocity(0)
        .AddLateralVelocity(0)
        .AddLateralMaxSpeed(config.RunMaxSpeed)
        .AddVelocity(Vector2.Zero)
        .With(e => e.isCharacter = true)
      ;
    
    return characterEntity;
  }
}