using Code.Infrastructure.Instantioator;
using Entitas;
using Godot;
using TreasureHunter.Code.Common.View;

namespace Code.Common.View.Factories
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private static readonly Vector3 _farAway = new(999, 999, 0);
    
    private readonly IInstantiator _instantiator;
    private readonly IEntityViewPool _pool;

    public EntityViewFactory(IInstantiator instantiator, IEntityViewPool pool)
    {
      //_objectResolver = objectResolver;
      _instantiator = instantiator;
      _pool = pool;
    }

    public IEntityView CreateViewForEntityFromPath(IEntity entity)
      => CreateEntityView(entity, entity.GetComponent<ViewPathComponent>().Value);

    public IEntityView CreateViewForEntityFromPrefab(IEntity entity) =>
      CreateEntityView(entity, entity.GetComponent<ViewPrefabComponent>().Value.GetPath());

    public void Release(IEntityView view)
    {
      view.Release();
      
      // view.GameObject.SetActive(false);
      // view.GameObject.transform.position = _farAway;
      
      _pool.Release(view.PoolKey, view);
    }

    private IEntityView CreateEntityView(IEntity entity, string path)
    {
      if (!_pool.TryRetain(path, out IEntityView view))
      {
        view = _instantiator.Instantiate<EntityViewNode>(path);
        view.PoolKey = path;
      }

      view.Retain(entity);

      return view;
    }
  }
}