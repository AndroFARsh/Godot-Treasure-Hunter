using Code.Gameplay.Character.CoyoteTimer.Systems;
using Code.Gameplay.Character.CoyoteTimer.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character.CoyoteTimer;

public sealed class CoyoteTimerFeature : Feature
{
  public CoyoteTimerFeature(ISystemFactory systems)
  {
    Add(systems.Create<StartCoyoteTimerSystem>());
    Add(systems.Create<CountDownCoyoteTimerSystem>());

#if DEBUG
    Add(systems.Create<CoyoteTimerDebugSystem>());
#endif
  }
}
