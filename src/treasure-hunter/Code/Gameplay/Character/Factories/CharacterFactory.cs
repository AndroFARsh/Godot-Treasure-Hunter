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
    return _entityFactory.CreateEntity<GameEntity>()
        .AddViewPrefab(config.Prefab)
        .AddFacing(1)
        .AddCharacterConfig(config)
        .AddGravity(config.GravityStrength)
        .With(e => e.isApplyGravity = true)
        .AddJumpVelocity(config.JumpVelocity)
        .AddMaxSpeed(config.RunMaxSpeed)
        .With(e => e.isDoConserveMomentum = config.DoConserveMomentum)
        .AddVelocity(Vector2.Zero)
        .With(e => e.isMovable = true)
        .With(e => e.isCharacter = true)
      ;
  }
}