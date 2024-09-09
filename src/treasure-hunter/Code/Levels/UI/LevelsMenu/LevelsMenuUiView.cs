using Code.Infrastructure.UI;
using Godot;

namespace Code.Levels.UI.LevelsMenu;

public partial class LevelsMenuUiView : BaseUiView<LevelsMenuUiView>
{
  [Export] public Label Title { get; private set; }
  [Export] public Control Content { get; private set; }
  [Export] public Button Back { get; private set; }
}