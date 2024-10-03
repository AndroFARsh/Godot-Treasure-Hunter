using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class UpdateViewVelocitySystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateViewVelocitySystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf( 
        GameMatcher.Velocity,
        GameMatcher.CharacterBody2D
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.CharacterBody2D.Velocity = entity.Velocity;
      entity.CharacterBody2D.MoveAndSlide();
    }
  }
}