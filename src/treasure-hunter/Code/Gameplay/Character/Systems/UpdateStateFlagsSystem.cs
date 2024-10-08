using Entitas;

namespace Code.Gameplay.Character.Systems;

public class UpdateStateFlagsSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateStateFlagsSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character,
        GameMatcher.CharacterBody2D,
        GameMatcher.AirVelocity
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      bool isOnFloor = entity.CharacterBody2D.IsOnFloor();

      entity.isPrevFrameOnFloor = entity.isOnFloor;
      entity.isPrevFrameInAir = entity.isInAir;

      entity.isOnFloor = isOnFloor;
      entity.isInAir = !isOnFloor;

      entity.isPrevFrameFalling = entity.isFalling;
      entity.isPrevFrameGoingUp = entity.isGoingUp;
      
      entity.isFalling = entity.isInAir && entity.AirVelocity > 0;
      entity.isGoingUp = entity.isInAir && entity.AirVelocity < 0;
    }
  }
}