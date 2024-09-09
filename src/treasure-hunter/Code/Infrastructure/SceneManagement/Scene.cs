using Godot;

namespace Code.Infrastructure.SceneManagement;

public partial class Scene : Node, IScene
{
  public Node Root => this;
  
  [Export] public Node ControlRoot { get; private set; }
  
  [Export] public Node WindowRoot { get; private set; }
  
  [Export] public Node WindowContainer { get; private set; }
}