using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Cameras.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Cameras;

public sealed class CameraFeature : Feature
{
  public CameraFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitCameraSystem>());
    Add(systems.Create<EnableCameraFollowSystem>());
    Add(systems.Create<EnableSnappingSystem>());
    
    Add(systems.Create<PositionLockingFollowSystem>());
    Add(systems.Create<HPositionLockingFollowSystem>());
    Add(systems.Create<CameraWindowFollowSystem>());
    
    Add(systems.Create<PositionSnappingSystem>());
    Add(systems.Create<PlatformSnappingSystem>());

#if DEBUG
    Add(systems.Create<PositionLockingDebugSystem>());
    Add(systems.Create<HPositionLockingDebugSystem>());
    
    Add(systems.Create<PositionSnappingDebugSystem>());
    Add(systems.Create<PlatformSnappingDebugSystem>());
    
    Add(systems.Create<CameraWindowDebugSystem>());
#endif
  }
}