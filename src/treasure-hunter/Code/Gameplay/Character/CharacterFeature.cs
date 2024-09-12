using Code.Gameplay.Character.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character;

public sealed class CharacterFeature : Feature
{
  public CharacterFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitCharacterSystem>());
    Add(systems.Create<MoveCharacterSystem>());
  }
}