using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class CheckIsLandedSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public CheckIsLandedSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.CharacterBody2D, GameMatcher.Air, GameMatcher.Velocity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      if (entity.CharacterBody2D.IsOnFloor())
      {
        Vector2 velocity = entity.Velocity;
        velocity.Y = 0;
        entity.ReplaceVelocity(velocity);
      }
  }
}