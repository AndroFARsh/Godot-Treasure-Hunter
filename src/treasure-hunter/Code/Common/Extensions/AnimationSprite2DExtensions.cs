using Godot;

namespace Code.Common.Extensions
{
  public static class AnimationSprite2DExtensions
  {
    public static void PlayIfNew(this AnimatedSprite2D sprite2D, StringName animation, float customSpeed = 1f, bool fromEnd = false)
    {
      if (sprite2D.Animation != animation)
        sprite2D.Play(animation, customSpeed, fromEnd);
    }
  }
}