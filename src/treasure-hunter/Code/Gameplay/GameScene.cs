using Code.Projects.Providers;
using Godot;
using Ninject;

namespace Code.Gameplay;

public partial class GameScene : Node
{
  [Export] private Node _root;

  private GameRootProvider _provider;

  [Inject]
  public void Construct(GameRootProvider provider)
  {
    _provider = provider;
  }

  public override void _EnterTree() => _provider.Retain(_root);

  public override void _ExitTree() => _provider.Release();
}