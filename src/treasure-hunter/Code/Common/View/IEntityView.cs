using Entitas;

namespace Code.Common.View
{
  public interface IEntityView
  {
    string PoolKey { get; set; }
    
    //GameObject GameObject { get; }
    
    void Retain(IEntity entity);
    void Release();
  }
}