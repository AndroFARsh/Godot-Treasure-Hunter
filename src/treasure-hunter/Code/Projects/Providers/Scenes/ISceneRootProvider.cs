using Godot;

namespace Code.Projects.Providers.Scenes;

public interface ISceneRootProvider
{
  Node Get { get; }
}