using Godot;
using Godot.Collections;

namespace Code.Infrastructure.UI.Windows.Configs;

[GlobalClass]
public partial class WindowConfig : Resource
{
  [Export(PropertyHint.Range, "0, 1")] public float MaxAlpha = 0.5f;
  
  [Export] public float FadeInSpeed = 0.3f;
  [Export] public Curve FadeInCurve;

  [Export] public float FadeOutSpeed = 0.3f;
  [Export] public Curve FadeOutCurve;
  
  [Export] public Array<WindowName2Prefab> Prefabs = new();
}