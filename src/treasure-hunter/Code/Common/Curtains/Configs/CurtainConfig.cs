using Godot;

namespace Code.Common.Curtains.Configs;

public partial class CurtainConfig: Resource
{
  [Export] public float FadeInSpeed = 0.5f;
  [Export] public Curve FadeInCurve;

  [Export] public float FadeOutSpeed = 0.5f;
  [Export] public Curve FadeOutCurve;
}