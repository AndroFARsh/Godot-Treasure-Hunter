using Code.Gameplay.Character.Lateral.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character.Lateral;

public class LateralFeature : Feature
{

  public LateralFeature(ISystemFactory systems)
  {
    Add(systems.Create<InputToHorizontalDirectionSystem>());
    Add(systems.Create<UpdateOnAirAccelerationSystem>());
    Add(systems.Create<UpdateOnGroundAccelerationSystem>());
  }
}