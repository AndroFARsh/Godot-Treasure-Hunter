using Code.Gameplay.Character.Jump.Systems;
using Code.Gameplay.Character.Jump.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character.Jump;

public sealed class JumpFeature : Feature
{
  public JumpFeature(ISystemFactory systems)
  {
    Add(systems.Create<CheckIsGroundJumpSystem>());
    Add(systems.Create<GroundJumpSystem>());
    
    Add(systems.Create<InterruptJumpSystem>());
    
    Add(systems.Create<UpdateFallGravityScaleSystem>());
    
#if DEBUG
    Add(systems.Create<UpdateDebugGroundPositionSystem>());
    Add(systems.Create<JumpHeightDebugSystem>());
#endif
  }
}