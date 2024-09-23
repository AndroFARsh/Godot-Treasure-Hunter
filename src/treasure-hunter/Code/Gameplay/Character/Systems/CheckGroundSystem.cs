using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CheckGroundSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public CheckGroundSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.CharacterBody2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.isGrounded = entity.CharacterBody2D.IsOnFloor();
  }
}