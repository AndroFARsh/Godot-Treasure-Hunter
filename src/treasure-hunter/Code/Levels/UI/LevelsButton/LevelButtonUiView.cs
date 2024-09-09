using Code.Infrastructure.UI;
using Godot;
using Ninject;

namespace Code.Levels.UI.LevelsButton;

public partial class LevelButtonUiView : BaseUiView<LevelButtonUiView>
{
  private int _level;
    
  [Export] public Button Button { get; private set; }
  
  public int Level { get; set; }
}