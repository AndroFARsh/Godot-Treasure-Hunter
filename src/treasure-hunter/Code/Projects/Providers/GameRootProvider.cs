using Godot;

namespace Code.Projects.Providers;

public class GameRootProvider : IGameRootProvider
{
  public Node Root { get; private set; }

  public void Retain(Node node) => Root = node;
  
  public void Release() => Root = null;
}