using Code.Gameplay.Character.Systems;
using Code.Gameplay.GameViews.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.GameViews;


public sealed class GameViewsFeature : Feature
{
  public GameViewsFeature(ISystemFactory systems)
  {
    Add(systems.Create<MergeVelocitySystem>());
    Add(systems.Create<UpdateViewFacingSystem>());
    Add(systems.Create<UpdateViewVelocitySystem>());
  }
}