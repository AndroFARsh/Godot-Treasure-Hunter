using Godot;

namespace Code.Infrastructure.SceneManagement;

public interface IScene
{
  Node Root { get; }
  Node ControlRoot { get; }
  Node WindowRoot { get; }
  Node WindowContainer { get; }
}