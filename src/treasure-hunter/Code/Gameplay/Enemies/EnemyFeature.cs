using Code.Gameplay.Enemies.Systems;
using Code.Gameplay.Enemies.Systems.Debugging;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Enemies;

public sealed class EnemyFeature : Feature
{
  public EnemyFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitSystem>());
    Add(systems.Create<UpdateForwardSensorsSystem>());
    Add(systems.Create<UpdateJumpHeightSensorsSystem>());
    Add(systems.Create<UpdateLedgeSensorsSystem>());
    
    Add(systems.Create<UpdateAnimationSystem>());

    // AI
    Add(systems.Create<TurnLateralDirectionOnWallReachSystem>());
    Add(systems.Create<TurnLateralDirectionOnLedgeReachSystem>());
    
    Add(systems.Create<ShouldJumpOnLedgeSystem>());
    
#if DEBUG
    Add(systems.Create<SensorVisualDebugSystem>());
#endif
  }
}