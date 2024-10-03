using Godot;

namespace Code.Projects.Providers.Game;

public interface IGameRootProvider
{
  Node Root { get; }
}