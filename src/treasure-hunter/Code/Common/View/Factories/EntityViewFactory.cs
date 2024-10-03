using Code.Infrastructure.Instantioator;
using Code.Projects.Providers;
using Code.Projects.Providers.Game;
using Entitas;
using Godot;

namespace Code.Common.View.Factories;

public class EntityViewFactory : IEntityViewFactory
{
  private readonly IInstantiator _instantiator;
  private readonly IEntityViewPool _pool;
  private readonly IGameRootProvider _provider;

  public EntityViewFactory(IInstantiator instantiator, IEntityViewPool pool, IGameRootProvider provider)
  {
    _instantiator = instantiator;
    _pool = pool;
    _provider = provider;
  }

  public IEntityView CreateViewForEntityFromPath(IEntity entity)
    => CreateEntityView(entity, entity.GetComponent<ViewPathComponent>().Value);

  public IEntityView CreateViewForEntityFromPrefab(IEntity entity) =>
    CreateEntityView(entity, entity.GetComponent<ViewPrefabComponent>().Value.GetPath());

  public void Release(IEntityView view)
  {
    view.Release();
    
    _provider.Root.RemoveChild(view.Node);
    
    _pool.Release(view.PoolKey, view);
  }

  private IEntityView CreateEntityView(IEntity entity, string path)
  {
    if (!_pool.TryRetain(path, out IEntityView view))
      view = _instantiator.Instantiate<EntityViewNode>(path);
    
    view.Retain(entity);
    _provider.Root.AddChild(view.Node);

    return view;
  }
}