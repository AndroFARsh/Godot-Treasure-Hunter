using Code.Gameplay.Character.Factories;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class InitSystem : IInitializeSystem
{
  private readonly ICharacterFactory _factory;

  public InitSystem(ICharacterFactory factory)
  {
    _factory = factory;
  }

  public void Initialize() => _factory.Create();
}