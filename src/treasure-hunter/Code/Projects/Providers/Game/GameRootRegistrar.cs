using Godot;
using Ninject;

namespace Code.Projects.Providers.Game;

public partial class GameRootRegistrar : Node2D
{
  private GameRootProvider _provider;

  [Inject]
  public void Construct(GameRootProvider provider)
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