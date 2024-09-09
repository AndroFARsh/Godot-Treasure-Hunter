using Godot;

namespace Code.Infrastructure.Windows.Configs;

[GlobalClass]
public partial class WindowServiceConfig : Resource
{
  [Export(PropertyHint.Range, "0, 1")] public float MaxAlpha = 0.5f;
  
  [Export] public float FadeInSpeed = 0.5f;
  [Export] public Curve FadeInCurve;

  [Export] public float FadeOutSpeed = 0.5f;
  [Export] public Curve FadeOutCurve;
  
  [Export] public WindowConfig[] Windows;
}