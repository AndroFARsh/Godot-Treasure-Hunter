using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CheckAirSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public CheckAirSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.CharacterBody2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.isAir = !entity.CharacterBody2D.IsOnFloor();
  }
}