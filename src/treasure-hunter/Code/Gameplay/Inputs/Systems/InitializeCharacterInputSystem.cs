using Code.Common.Extensions;
using Code.Infrastructure.EntityFactories;
using Entitas;

namespace Code.Gameplay.Inputs.Systems;

public class InitializeCharacterInputSystem : IInitializeSystem
{
  private readonly IEntityFactory _entityFactory;

  public InitializeCharacterInputSystem(IEntityFactory entityFactory)
  {
    _entityFactory = entityFactory;
  }

  public void Initialize() => _entityFactory.CreateEntity<InputEntity>()
    .AddLateralDirection(0)
    .With(e => e.isCharacter = true);
}