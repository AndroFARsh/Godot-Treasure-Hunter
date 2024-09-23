using Code.Gameplay.Cameras.Configs;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Cameras.Factories;

public class CameraFactory : ICameraFactory
{
  private readonly IEntityFactory _entityFactory;
  private readonly IStaticDataService _staticDataService;
  
  public CameraFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
  {
    _entityFactory = entityFactory;
    _staticDataService = staticDataService;
  }
  
  public GameEntity Create()
  {
    CameraConfig config = _staticDataService.CameraConfig;
    return _entityFactory.CreateEntity<GameEntity>()
        .AddViewPrefab(config.Prefab)
      ;
  }
}