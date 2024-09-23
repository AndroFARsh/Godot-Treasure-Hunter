using Code.Gameplay.Cameras.Factories;
using Entitas;

namespace Code.Gameplay.Cameras.Systems;

public class InitCameraSystem : IInitializeSystem
{
  private readonly ICameraFactory _cameraFactory;

  public InitCameraSystem(ICameraFactory cameraFactory)
  {
    _cameraFactory = cameraFactory;
  }
  
  public void Initialize() => _cameraFactory.Create();
}