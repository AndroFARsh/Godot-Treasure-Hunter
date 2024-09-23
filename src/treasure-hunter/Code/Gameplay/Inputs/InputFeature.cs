using Code.Gameplay.Inputs.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Inputs;

public class InputFeature : Feature
{
  public InputFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitializeCharacterInputSystem>());
    
    Add(systems.Create<UpdateHorizontalDirectionInputSystem>());
    Add(systems.Create<UpdateJumpInputSystem>());
    
    Add(systems.Create<CleanupJumpInputSystem>());
  }
}