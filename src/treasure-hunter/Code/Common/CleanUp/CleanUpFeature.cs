using Code.Common.CleanUp.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.CleanUp
{
  public sealed class CleanUpFeature : Feature
  {
    public CleanUpFeature(ISystemFactory systems)
    {
      Add(systems.Create<SelfDestructedEntityTimerSystem<GameEntity>>());
      Add(systems.Create<SelfDestructedEntityTimerSystem<InputEntity>>());
      Add(systems.Create<SelfDestructedEntityTimerSystem<MetaEntity>>());
     
      Add(systems.Create<CleanupEntityViewSystem<GameEntity>>());
      Add(systems.Create<CleanupEntityViewSystem<InputEntity>>());
      Add(systems.Create<CleanupEntityViewSystem<MetaEntity>>());
      
      Add(systems.Create<CleanupEntitySystem<GameEntity>>());
      Add(systems.Create<CleanupEntitySystem<InputEntity>>());
      Add(systems.Create<CleanupEntitySystem<MetaEntity>>());

      Add(systems.Create<CeanaupPoolSystem>());
    }
  }
}