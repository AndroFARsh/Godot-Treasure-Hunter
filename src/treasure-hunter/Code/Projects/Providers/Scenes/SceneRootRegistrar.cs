using Godot;
using Ninject;

namespace Code.Projects.Providers.Scenes;

public partial class SceneRootRegistrar : Node
{
  private SceneRootProvider _provider;

  [Inject]
  public void Construct(SceneRootProvider provider)
  {
    _provider = provider;
    _provider.Retain(this);
  }

  public override void _Notification(int what)
  {
    if (what == NotificationPredelete)
    {
      _provider.Release();
      _provider = null;
    }
  }
}