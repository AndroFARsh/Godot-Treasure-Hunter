using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Common.CleanUp.Systems
{
  public class SelfDestructedEntityTimerSystem<TEntity> : IExecuteSystem
    where TEntity : class, IEntity
  {
    private readonly ITimeService _time;
    private readonly IGroup<TEntity> _entities;

    public SelfDestructedEntityTimerSystem(ITimeService time, IEntityFactory factory)
    {
      _time = time;
      _entities = factory.BuildGroup<TEntity>()
        .With<SelfDestroyTimerComponent>()
        .Build();
    }

    public void Execute()
    {
      foreach (TEntity entity in _entities)
      {
        if (entity.TryGetComponent(out SelfDestroyTimerComponent timer))
        {
          timer.Value -= _time.DeltaTime;
          entity.TryReplaceComponent(timer);

          if (timer.Value <= 0)
            entity.TryReplaceComponent(new ReadyToCleanUpComponent());
        }
      }
    }
  }
}