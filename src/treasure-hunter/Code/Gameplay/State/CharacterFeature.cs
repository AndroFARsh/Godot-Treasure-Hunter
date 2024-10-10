using Code.Gameplay.Character.Systems;
using Code.Gameplay.State.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.State;

public sealed class StateFeature : Feature
{
  public StateFeature(ISystemFactory systems)
  {
    Add(systems.Create<UpdateStateFlagsSystem>());
  }
}