using Code.Gameplay.LateralMove.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.LateralMove;

public sealed class LateralFeature : Feature
{
  public LateralFeature(ISystemFactory systems)
  {
    Add(systems.Create<UpdateFacingSystem>());
    Add(systems.Create<UpdateLateralVelocitySystem>());
  }
}