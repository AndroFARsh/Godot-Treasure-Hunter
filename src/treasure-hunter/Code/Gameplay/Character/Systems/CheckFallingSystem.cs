using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CheckFallingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public CheckFallingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, 
        GameMatcher.CharacterBody2D, 
        GameMatcher.Velocity,
        GameMatcher.Gravity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.isFalling = entity.Velocity.Dot(entity.Gravity) > 0;
  }
}