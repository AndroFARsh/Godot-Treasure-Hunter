using Code.Infrastructure.UI;
using Godot;

namespace Code.Gameplay.HUD;

public partial class GameHUDView : BaseUiView
{
  [Export] public BaseButton Menu { get; private set; }
}