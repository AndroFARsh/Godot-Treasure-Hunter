using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class UpdateAirGroundStateSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public UpdateAirGroundStateSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.CharacterBody2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      bool grounded = entity.CharacterBody2D.IsOnFloor();
      entity.isAir = !grounded;
      entity.isGrounded = grounded;
      if (entity.isGrounded && entity.hasAirVelocity)
        entity.RemoveAirVelocity();
    }
  }
}