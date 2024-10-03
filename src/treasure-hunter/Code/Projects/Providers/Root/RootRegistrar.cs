using Godot;
using Ninject;

namespace Code.Projects.Providers.Root;

public partial class RootRegistrar : Node
{
  [Export] private Node _root;

  private RootProvider _provider;

  [Inject]
  public void Construct(RootProvider provider)
  {
    _provider = provider;
    _provider.Retain(_root ?? this);
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