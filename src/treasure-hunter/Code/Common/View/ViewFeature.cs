using Code.Common.View.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.View
{
  public sealed class ViewFeature : Feature
  {
    public ViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<CreateEntityViewFromPrefabSystem<MetaEntity>>());
      Add(systems.Create<CreateEntityViewFromPathSystem<MetaEntity>>());
      
      Add(systems.Create<CreateEntityViewFromPrefabSystem<InputEntity>>());
      Add(systems.Create<CreateEntityViewFromPathSystem<InputEntity>>());
      
      Add(systems.Create<CreateEntityViewFromPrefabSystem<GameEntity>>());
      Add(systems.Create<CreateEntityViewFromPathSystem<GameEntity>>());
    }
  }
}