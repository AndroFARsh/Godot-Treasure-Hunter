using Code.Common.Extensions;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class UpdateAnimationSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public UpdateAnimationSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Enemy, 
        GameMatcher.AirVelocity,
        GameMatcher.AnimatedSprite2D,
        GameMatcher.LateralDirection)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      AnimatedSprite2D sprite2D = entity.AnimatedSprite2D;
      if (entity.isInAir)
      {
        if (entity.isGoingUp)
          sprite2D.PlayIfNew("jump");
        else if (entity.isFalling)
          sprite2D.PlayIfNew("fall");
      }
      else
      {
        sprite2D.Play(entity.LateralDirection != 0 ? "run" : "idle");
      }
    }
  }
}