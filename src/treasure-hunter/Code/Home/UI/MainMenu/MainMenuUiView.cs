using Code.Infrastructure.UI;
using Godot;

namespace Code.Home.UI.MainMenu;

public partial class MainMenuUiView : BaseUiView
{
  [ExportGroup("Title")]
  [Export] public Label Title { get; private set; }
  
  [ExportGroup("Menu")]
  [Export] public Button Play { get; private set; }
  [Export] public Button Settings { get; private set; }
  [Export] public Button Quit { get; private set; }
  
  [ExportGroup("Version")]
  [Export] public Label Version { get; private set; }
}