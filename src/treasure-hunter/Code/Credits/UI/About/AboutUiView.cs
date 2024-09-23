using Code.Infrastructure.UI;
using Godot;

namespace Code.Credits.UI.About;

public partial class AboutUiView : BaseUiView
{
  [Export] public Label Title { get; private set; }
  [Export] public Label Version { get; private set; }
  [Export] public BaseButton Eula { get; private set; }
  [Export] public BaseButton PrivacyPolicy { get; private set; }
  
  [Export(PropertyHint.MultilineText)] public Label Credits { get; private set; }
  [Export] public Button Back { get; private set; }
}