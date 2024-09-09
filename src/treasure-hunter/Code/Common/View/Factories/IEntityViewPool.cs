using TreasureHunter.Code.Common.View;

namespace Code.Common.View.Factories
{
  public interface IEntityViewPool
  {
    bool TryRetain(string resource, out IEntityView result);
    void Release(string resource, IEntityView view);
    void CleanUp();
  }
}