using Code.Gameplay.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Enemies;

public sealed class EnemyFeature : Feature
{
  public EnemyFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitSystem>());

    Add(systems.Create<UpdateAnimationSystem>());
  }
}