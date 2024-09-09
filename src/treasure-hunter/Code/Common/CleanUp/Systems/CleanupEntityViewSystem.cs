using System.Collections.Generic;
using Code.Common.View.Factories;
using Code.Infrastructure.EntityFactories;
using Entitas;

namespace Code.Common.CleanUp.Systems
{
  public class CleanupEntityViewSystem<TEntity> : ICleanupSystem, ITearDownSystem
    where TEntity : class, IEntity
  {
    private readonly IEntityViewFactory _viewFactory;

    private readonly IGroup<TEntity> _entities;
    private readonly List<TEntity> _buffer = new(128);

    public CleanupEntityViewSystem(IEntityFactory factory, IEntityViewFactory viewFactory)
    {
      _viewFactory = viewFactory;
      _entities = factory.BuildGroup<TEntity>()
          .With<ReadyToCleanUpComponent>()
          .With<ViewComponent>()
          .Build();
    }

    public void Cleanup() => ProcessCleanup();

    public void TearDown() => ProcessCleanup();

    private void ProcessCleanup()
    {
      foreach (TEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.TryGetComponent(out ViewComponent view))
        {
          _viewFactory.Release(view.Value);
        }
      }
    }
  }
}