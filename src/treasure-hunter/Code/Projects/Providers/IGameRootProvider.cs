using Godot;

namespace Code.Projects.Providers;

public interface IGameRootProvider
{
  Node Root { get; }
}