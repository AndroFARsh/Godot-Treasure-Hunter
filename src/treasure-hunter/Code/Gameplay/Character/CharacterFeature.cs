using Code.Gameplay.Character.Systems;
using Code.Gameplay.Character.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character;

public sealed class CharacterFeature : Feature
{
  public CharacterFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitSystem>());
    
    Add(systems.Create<CountdownCoyoteTimerSystem>());
    Add(systems.Create<CountdownJumpBufferInputTimerSystem>());
    Add(systems.Create<CountdownJumpApexHangTimerSystem>());
    
    Add(systems.Create<UpdateStateFlagsSystem>());
    Add(systems.Create<UpdateGravityScaleSystem>());
    Add(systems.Create<ApplyGravitySystem>());

    Add(systems.Create<HandleJustLandedSystem>());
    Add(systems.Create<HandleGroundJumpSystem>());
    Add(systems.Create<HandleAirJumpSystem>());
    
    Add(systems.Create<UpdateFacingSystem>());
    Add(systems.Create<ApplyLateralMovementSystem>());

    Add(systems.Create<UpdateAnimationSystem>());
    Add(systems.Create<MergeVelocitySystem>());

#if DEBUG
    Add(systems.Create<JumpHeightDebugSystem>());
    Add(systems.Create<CoyoteTimerDebugSystem>());
    Add(systems.Create<JumpBufferInputTimerDebugSystem>());
#endif
  }
}