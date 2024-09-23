using Code.Infrastructure.UI;
using Godot;

namespace Code.Levels.UI.LevelsMenu;

public partial class LevelsMenuUiView : BaseUiView
{
  [Export] public Label Title { get; private set; }
  [Export] public Control Content { get; private set; }
  [Export] public Button Back { get; private set; }
}