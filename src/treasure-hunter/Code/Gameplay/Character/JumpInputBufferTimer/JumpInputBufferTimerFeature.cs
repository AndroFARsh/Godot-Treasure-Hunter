using Code.Gameplay.Character.JumpInputBufferTimer.Systems;
using Code.Gameplay.Character.JumpInputBufferTimer.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character.JumpInputBufferTimer;

public sealed class JumpInputBufferTimerFeature : Feature
{
  public JumpInputBufferTimerFeature(ISystemFactory systems)
  {
    Add(systems.Create<StartJumpInputBufferTimerSystem>());
    Add(systems.Create<CountDownJumpInputBufferTimerSystem>());

#if DEBUG
    Add(systems.Create<JumpInputBufferTimerDebugSystem>());
#endif
  }
}
