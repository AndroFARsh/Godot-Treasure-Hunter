using Code.Common.CleanUp;
using Code.Common.View;
using Code.Gameplay.Cameras;
using Code.Gameplay.Character;
using Code.Gameplay.Inputs;
using Code.Infrastructure.Systems;

namespace Code.Gameplay;

public class GameplayFeature : Feature
{
  public GameplayFeature(ISystemFactory systems)
  {
    Add(systems.Create<InputFeature>());
    
    Add(systems.Create<CharacterFeature>());
    Add(systems.Create<CameraFeature>());

    Add(systems.Create<ViewFeature>());
    Add(systems.Create<CleanUpFeature>());
  }
}