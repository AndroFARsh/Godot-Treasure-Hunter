using Code.Gameplay.Character.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character;

public sealed class CharacterFeature : Feature
{
  public CharacterFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitCharacterSystem>());
    
    Add(systems.Create<UpdateCharacterFacingSystem>());
    Add(systems.Create<UpdateGravityVectorSystem>());

    Add(systems.Create<CountdownCoyoteTimerSystem>());
    Add(systems.Create<CheckIsCoyoteTimeStartedSystem>());
    Add(systems.Create<CheckIsLandedSystem>());
    Add(systems.Create<CheckGroundSystem>());
    Add(systems.Create<CheckAirSystem>());
    Add(systems.Create<CheckFallingSystem>());
    
    Add(systems.Create<ApplyJumpSystem>());
    Add(systems.Create<InterruptJumpSystem>());
    Add(systems.Create<UpdateCharacterGroundHorizontalVelocitySystem>());
    Add(systems.Create<UpdateCharacterViewSystem>());
    
    Add(systems.Create<ApplyGravitySystem>());
    
    // Add(systems.Create<SimpleMoveCharacterSystem>());
  }
}