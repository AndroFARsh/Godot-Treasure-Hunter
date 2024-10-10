using Code.Gameplay.LateralMovement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.LateralMovement;

public sealed class LateralMovementFeature : Feature
{
  public LateralMovementFeature(ISystemFactory systems)
  {
    Add(systems.Create<ApplyLateralMovementSystem>());
    Add(systems.Create<UpdateFacingSystem>());
  }
}