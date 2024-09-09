using System.Collections.Generic;
using Code.Common.View.Factories;
using Code.Infrastructure.EntityFactories;
using Entitas;

namespace Code.Common.View.Systems
{
  public class CreateEntityViewFromPrefabSystem<TEntity> : IExecuteSystem
    where TEntity : class, IEntity
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly IGroup<TEntity> _entities;
    private readonly List<TEntity> _buffer = new(128);

    public CreateEntityViewFromPrefabSystem(IEntityFactory entityFactory, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = entityFactory.BuildGroup<TEntity>().With<ViewPrefabComponent>().With<ViewComponent>().Build();
    }

    public void Execute()
    {
      foreach (TEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntityFromPrefab(entity);
    }
  }
}