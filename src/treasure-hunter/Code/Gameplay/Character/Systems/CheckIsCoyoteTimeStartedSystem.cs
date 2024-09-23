using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CheckIsCoyoteTimeStartedSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public CheckIsCoyoteTimeStartedSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(
        GameMatcher.Character, 
        GameMatcher.CharacterBody2D,
        GameMatcher.Grounded,
        GameMatcher.CoyoteTime));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      if (!entity.CharacterBody2D.IsOnFloor())
        entity.ReplaceCoyoteTimer(entity.CoyoteTime);
      
  }
}