using Godot;

namespace Code.Gameplay.Common.Nodes;

[Tool]
[GlobalClass]
public partial class LandAnimator2D : Node
{
  [Export] private Node2D _node2D;
  
  private Vector2 _initialScale;
  private Vector2 _squashedScale;
  
  public override string[] _GetConfigurationWarnings() => 
    _node2D == null 
      ? new []{"Please attach node2d that would be affected"} 
      : default;

  public void Play(float scaleFactor, float duration)
  {
    Tween tween = CreateTween();
    tween.SetEase(Tween.EaseType.OutIn);
    tween.SetTrans(Tween.TransitionType.Spring);
    tween.TweenProperty(_node2D, "scale", new Vector2(1 + scaleFactor, 1 - scaleFactor), duration);
    tween.TweenProperty(_node2D, "scale", new Vector2(1, 1), duration);
  }
}