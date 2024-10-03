using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class UpdateAirSubStateSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public UpdateAirSubStateSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.ApplyGravity, 
        GameMatcher.CharacterBody2D, 
        GameMatcher.Gravity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.isFalling = entity.CharacterBody2D.Velocity.Y * entity.Gravity > 0 && entity.isAir;
      entity.isRising = entity.CharacterBody2D.Velocity.Y * entity.Gravity < 0 && entity.isAir;
      entity.isLanding = entity.CharacterBody2D.IsOnFloor() && entity.isAir;
    }
  }
}