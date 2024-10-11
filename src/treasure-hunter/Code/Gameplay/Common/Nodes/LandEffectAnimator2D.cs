using Godot;

namespace Code.Gameplay.Common.Nodes;

public partial class LandEffectAnimator2D : Node2D
{
  private Vector2 _initialScale;
  private Vector2 _squashedScale;
  
  public void Play(float scaleFactor = 0.4f, float duration = 0.1f)
  {
    Tween tween = CreateTween();
    tween.SetEase(Tween.EaseType.OutIn);
    tween.SetTrans(Tween.TransitionType.Spring);
    tween.TweenProperty(this, "scale", new Vector2(1 + scaleFactor, 1 - scaleFactor), duration);
    tween.TweenProperty(this, "scale", new Vector2(1, 1), duration);
  }
}