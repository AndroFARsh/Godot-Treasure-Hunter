using Code.Common.Extensions;
using Code.Gameplay.Character.Configs;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.StaticData;

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
    return _entityFactory.CreateEntity<GameEntity>()
        .AddViewPrefab(config.Prefab)
        .With(e => e.isCharacter = true)
      ;
  }
}