using Code.Common.CleanUp;
using Code.Infrastructure.Systems;

namespace Code.Home
{
  public sealed class HomeFeature : Feature
  {
    public HomeFeature(ISystemFactory systems)
    {
      // Add(systems.Create<PlayHomeMusicSystem>());
      
      Add(systems.Create<CleanUpFeature>());
    }
  }
}