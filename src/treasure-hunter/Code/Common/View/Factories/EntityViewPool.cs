using System;
using System.Collections.Generic;

namespace Code.Common.View.Factories;

public class EntityViewPool : IEntityViewPool, IDisposable
{
  private readonly Dictionary<string, LinkedList<IEntityView>> _pools = new(4);

  public bool TryRetain(string resource, out IEntityView result)
  {
    result = null;
    if (_pools.TryGetValue(resource, out LinkedList<IEntityView> pool) && pool.Count > 0)
    {
      if (pool.First != null) result = pool.First.Value;
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
        entityView.Node.QueueFree();
      
      pool.Clear();
    }
  }

  public void Dispose() => CleanUp();
}