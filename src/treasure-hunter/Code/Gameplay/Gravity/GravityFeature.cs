using Code.Gameplay.Gravity.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Gravity;

public sealed class GravityFeature : Feature
{
  public GravityFeature(ISystemFactory systems)
  {
    Add(systems.Create<UpdateAirSubStateSystem>());
    Add(systems.Create<UpdateAirGroundStateSystem>());
    
    Add(systems.Create<GravitySystem>());
    
    Add(systems.Create<CleanupGravityScaleSystem>());
  }
}