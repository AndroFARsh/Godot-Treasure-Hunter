using Code.Infrastructure.Windows;
using Godot;

namespace Code.SettingsWindow;

public partial class SettingsWindowView : BaseWindow
{
  [ExportCategory("Title")]
  [Export] public Label Title { get; private set; }
  
  [ExportCategory("Content")]
  [Export] public Slider General { get; private set; }
  [Export] public Slider Music { get; private set; }
  [Export] public Slider Effect { get; private set; }
  
  [Export] public BaseButton Credits { get; private set; }
  
  [ExportCategory("Footer")]
  [Export] public Button Back { get; private set; }
  [Export] public Button Save { get; private set; }
}