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
        .AddFacingFlip(false)
        .AddCharacterConfig(config)
        .AddGravityScale(1)
        .AddAirVelocity(0)
        .AddLateralVelocity(0)
        .AddVelocity(Vector2.Zero)
        .With(e => e.isCharacter = true)
      ;
    
    return characterEntity;
  }
}