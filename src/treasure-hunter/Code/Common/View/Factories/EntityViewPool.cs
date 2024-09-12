using System.Collections.Generic;

namespace Code.Common.View.Factories;

public class EntityViewPool : IEntityViewPool
{
  private readonly Dictionary<string, LinkedList<IEntityView>> _pools = new(4);

  public bool TryRetain(string resource, out IEntityView result)
  {
    result = null;
    if (_pools.TryGetValue(resource, out LinkedList<IEntityView> pool) && pool.Count > 0)
    {
      result = pool.First.Value;
      // result.GameObject.SetActive(true);
      pool.RemoveFirst();
    }

    return result != null;
  }
    
  public void Release(string resource, IEntityView view)
  {
    if (resource == null) return;
      
    if (!_pools.TryGetValue(resource, out LinkedList<IEntityView> pool))
    {
      pool = new LinkedList<IEntityView>();
      _pools.Add(resource, pool);
    }

    pool.AddLast(view);
  }

  public void CleanUp()
  {
    foreach (LinkedList<IEntityView> pool in _pools.Values)
    {
      foreach (IEntityView entityView in pool)
      {
        // Object.Destroy(entityView.GameObject);
      }
      pool.Clear();
    }
  }
}