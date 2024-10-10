using Code.Gameplay.Gravity.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Gravity;

public class GravityFeature : Feature
{
  public GravityFeature(ISystemFactory systems)
  {
    Add(systems.Create<ApplyGravitySystem>());
    Add(systems.Create<ClampFallSpeedSystem>());
  }
}