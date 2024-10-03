using Godot;

namespace Code.Projects.Providers.Scenes;

public class SceneRootProvider : ISceneRootProvider
{
  public Node Get { get; private set; }
  public void Retain(Node node) => Get = node;

  public void Release() => Get = null;
}