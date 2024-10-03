using Godot;

namespace Code.Projects.Providers.Root;

public class RootProvider : IRootProvider
{
  private Node _root;
  
  public Node Get => _root;

  public void Quit() => _root.GetTree().Quit(); 

  public void Retain(Node node) => _root = node;

  public void Release() => _root = null;
}