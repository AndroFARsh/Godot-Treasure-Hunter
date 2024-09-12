using Entitas;
using Godot;

namespace Code.Common.View
{
  public interface IEntityView
  {
    string PoolKey { get; }
    
    Node Node { get; }
    
    void Retain(IEntity entity);
    void Release();
  }
}