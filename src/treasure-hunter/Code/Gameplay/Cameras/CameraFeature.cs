using Code.Gameplay.Cameras.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Cameras;

public sealed class CameraFeature : Feature
{
  public CameraFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitCameraSystem>());
    Add(systems.Create<UpdateCameraPositionSystem>());
  }
}