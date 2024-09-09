using Code.Infrastructure.UI;
using Godot;

namespace Code.Gameplay.HUD;

public partial class GameHUDView : BaseUiView<GameHUDView>
{
  [Export] public BaseButton Menu { get; private set; }
}