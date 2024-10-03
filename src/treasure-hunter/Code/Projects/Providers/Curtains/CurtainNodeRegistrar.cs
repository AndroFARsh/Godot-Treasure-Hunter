using Code.Projects.Providers.Scenes;
using Godot;
using Ninject;

namespace Code.Projects.Providers.Curtains;

public partial class CurtainNodeRegistrar : ColorRect
{
  private CurtainNodeProvider _provider;

  [Inject]
  public void Construct(CurtainNodeProvider provider)
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