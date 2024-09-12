using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Infrastructure.EntityFactories;

public class EntityFactory : IEntityFactory
{
  private readonly Dictionary<Type, string> _entityTypeToContextName = new();
  private readonly Dictionary<string, IContext> _contextNameToContext;
  private readonly IIdProvider _idProvider;

  public EntityFactory(IIdProvider idProvider)
  {
    _idProvider = idProvider;
    _contextNameToContext = Contexts.sharedInstance.allContexts
      .ToDictionary(c => c.contextInfo.name, c => c);
  }

  public TEntity CreateEntity<TEntity>() where TEntity : class, IEntity
  {
    string name = GetContextName(typeof(TEntity));
      
    IContext<TEntity> context = _contextNameToContext[name] as IContext<TEntity>;
      
    TEntity entity = context?.CreateEntity();
    entity?.AddComponent(new IdComponent { Value = _idProvider.NextId });
      
    return entity;
  }

  public IGroup<TEntity> CreateGroup<TEntity>(IMatcher<TEntity> matcher) where TEntity : class, IEntity
  {
    string name = GetContextName(typeof(TEntity));
      
    IContext<TEntity> context = _contextNameToContext[name] as IContext<TEntity>;

    return context?.GetGroup(matcher);
  }

  public IGroupBuilder<TEntity> BuildGroup<TEntity>() where TEntity : class, IEntity => 
    new GroupBuilder<TEntity>(this);

  private string GetContextName(Type type)
  {
    if (_entityTypeToContextName.TryGetValue(type, out string name)) return name;
      
    name = type.Name.Replace("Entity", "");
    _entityTypeToContextName.Add(type, name);
    return name;
  }
}