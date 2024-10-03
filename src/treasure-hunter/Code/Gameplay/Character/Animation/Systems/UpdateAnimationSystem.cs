using Entitas;
using Godot;

namespace Code.Gameplay.Character.Animation.Systems;

public class UpdateAnimationSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateAnimationSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(
        GameMatcher.AnimatedSprite2D, 
        GameMatcher.Velocity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      AnimatedSprite2D animatedSprite2D = entity.AnimatedSprite2D;
      Vector2 velocity = entity.Velocity;
      if (entity.isLanding || 
         (animatedSprite2D.Animation == "ground" && animatedSprite2D.IsPlaying()))
      { 
        if (animatedSprite2D.Animation == "ground") return;
        
        GD.PrintErr("ground");
        animatedSprite2D.Play("ground");
      }
      else if (entity.isAir)
      {
        if (entity.isRising) {
          if (animatedSprite2D.Animation == "jump") return;
          
          GD.PrintErr("jump");
          animatedSprite2D.Play("jump");
        }
        else if (entity.isFalling)
        {
          if (animatedSprite2D.Animation == "fall") return;
          
          GD.PrintErr("fall");
          animatedSprite2D.Play("fall");
        }
      }
      else if (velocity.Y == 0 &&  Mathf.Abs(velocity.X) > 1)
      {
        if (animatedSprite2D.Animation == "run") return;
        
        GD.PrintErr("run");
        animatedSprite2D.Play("run");
      }
      else 
      {
        if (animatedSprite2D.Animation == "idle") return;
        
        GD.PrintErr("idle");
        animatedSprite2D.Play("idle");
      }
    }
  }
}