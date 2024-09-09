using Godot;

namespace Code.Projects;

public interface IProject
{
  Node SceneRoot { get; }
  ColorRect Curtain { get; }

  public void Quit();
}