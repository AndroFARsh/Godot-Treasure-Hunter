using System;
using System.Collections.Generic;
using Code.Common.Extensions;
using Entitas;

namespace Code.Infrastructure.EntityFactories
{
  public readonly struct GroupBuilder<TEntity> : IGroupBuilder<TEntity>
    where TEntity : class, IEntity
  {
    private static readonly Dictionary<Type, Type[]> _allowedComponentsByEntity = new Dictionary<Type, Type[]>()
      .With(d => d.Add(typeof(GameEntity), GameComponentsLookup.componentTypes))
      .With(d => d.Add(typeof(InputEntity), InputComponentsLookup.componentTypes))
      .With(d => d.Add(typeof(MetaEntity), MetaComponentsLookup.componentTypes));
    
    private readonly IEntityFactory _factory;
    private readonly List<int> _allOf;
    private readonly List<int> _anyOf;
    private readonly List<int> _nonOf;

    public GroupBuilder(IEntityFactory factory)
    {
      _factory = factory;
      _allOf = new List<int>(8);
      _anyOf = new List<int>(2);
      _nonOf = new List<int>(1);
    }

    public IGroupBuilder<TEntity> With<TComponent>() where TComponent : IComponent
    {
      if (TryGetComponentIndex<TComponent>(out int index))
        _allOf.Add(index);
      
      return this;
    }

    public IGroupBuilder<TEntity> Any<TComponent>() where TComponent : IComponent
    {
      if (TryGetComponentIndex<TComponent>(out int index))
        _anyOf.Add(index);
      
      return this;
    }

    public IGroupBuilder<TEntity> Non<TComponent>() where TComponent : IComponent
    {
      if (TryGetComponentIndex<TComponent>(out int index))
        _nonOf.Add(index);
      
      return this;
    }

    public IGroup<TEntity> Build() => _factory.CreateGroup(BuildMatcher());

    private IMatcher<TEntity> BuildMatcher()
    {
      IAllOfMatcher<TEntity> matcher = Matcher<TEntity>.AllOf(_allOf.ToArray());
      if (!_anyOf.IsNullOrEmpty())
        matcher.AnyOf(_anyOf.ToArray());
      if (!_nonOf.IsNullOrEmpty())
        matcher.NoneOf(_nonOf.ToArray());
      return matcher;
    }

    private bool TryGetComponentIndex<TComponent>(out int componentIndex)
    {
      componentIndex = -1;
      
      Type entityType = typeof(TEntity);
      Type componentType = typeof(TComponent);
      if (_allowedComponentsByEntity.TryGetValue(entityType, out Type[] types))
        componentIndex = Array.IndexOf(types, componentType);
      
      return componentIndex > 0;
    }
  }
}