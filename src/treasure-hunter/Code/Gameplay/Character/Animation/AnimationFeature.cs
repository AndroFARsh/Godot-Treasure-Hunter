using Code.Gameplay.Character.Animation.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character.Animation;

public sealed class AnimationFeature : Feature
{
  public AnimationFeature(ISystemFactory systems)
  {
    Add(systems.Create<UpdateAnimationSystem>());
  }
}