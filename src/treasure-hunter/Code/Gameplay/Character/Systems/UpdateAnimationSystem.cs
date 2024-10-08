using Code.Common.Extensions;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class UpdateAnimationSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public UpdateAnimationSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(
      InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection)
    );
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character, 
        GameMatcher.AirVelocity,
        GameMatcher.AnimatedSprite2D)
    );
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
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
        sprite2D.Play(input.HorizontalDirection != 0 ? "run" : "idle");
      }
    }
  }
}