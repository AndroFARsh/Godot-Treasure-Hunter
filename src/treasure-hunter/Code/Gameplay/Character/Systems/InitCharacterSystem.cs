using Code.Gameplay.Character.Factories;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class InitCharacterSystem : IInitializeSystem
{
  private readonly ICharacterFactory _characterFactory;

  public InitCharacterSystem(ICharacterFactory characterFactory)
  {
    _characterFactory = characterFactory;
  }
  
  public void Initialize()
  {
    _characterFactory.Create();
  }
}