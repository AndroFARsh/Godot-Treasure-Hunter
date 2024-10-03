using Godot;

namespace Code.Projects.Providers.Root;

public interface IRootProvider
{
  Node Get { get; }

  void Quit();
}