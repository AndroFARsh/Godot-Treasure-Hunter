using Code.Infrastructure.Windows;
using Godot;

namespace Code.Gameplay.Windows.MenuWindow;

public partial class GameMenuWindowView : BaseWindow
{
  [ExportCategory("Title")]
  [Export] public Label Title { get; private set; }
  
  [ExportCategory("Content")]
  [Export] public BaseButton Resume { get; private set; }
  [Export] public BaseButton Settings { get; private set; }
  [Export] public BaseButton MainMenu { get; private set; }
  
}