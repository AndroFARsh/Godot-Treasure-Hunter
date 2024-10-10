using Code.Common.Extensions;
using Code.Gameplay.Enemies.Configs;
using Code.Infrastructure.EntityFactories;
using Code.StaticData;
using Godot;

namespace Code.Gameplay.Enemies.Factories;

public class EnemyFactory : IEnemyFactory
{
  private readonly IEntityFactory _entityFactory;
  private readonly IStaticDataService _staticDataService;

  public EnemyFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
  {
    _entityFactory = entityFactory;
    _staticDataService = staticDataService;
  }

  public GameEntity Create(EnemyName name, Vector2 at)
  {
    EnemyConfig config = _staticDataService.GetEnemyConfig(name);
    return _entityFactory.CreateEntity<GameEntity>()
        .With(e => e.isEnemy = true)
        .AddEnemyName(name)
        .AddViewPrefab(config.Prefab)
        .AddWorldPosition2D(at)
        .With(e => e.isApplyGravity = true)
        .AddGravityStrength(config.GravityStrength)
        .AddGravityScale(1)
        .AddFallMaxSpeed(config.FallMaxSpeed)
        .AddAirVelocity(0)
        .AddLateralVelocity(0)
        .AddLateralMaxSpeed(config.RunMaxSpeed)
        .AddLateralDirection(-1)
        .AddFacing(1)
      ;
  }
}