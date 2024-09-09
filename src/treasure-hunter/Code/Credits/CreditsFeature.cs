using Code.Common.CleanUp;
using Code.Infrastructure.Systems;

namespace Code.Credits
{
  public class CreditsFeature : Feature
  {
    public CreditsFeature(ISystemFactory systems)
    {
      Add(systems.Create<CleanUpFeature>());
    }
  }
}