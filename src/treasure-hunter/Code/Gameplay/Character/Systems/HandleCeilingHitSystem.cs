using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Systems;

public class HandleCeilingHitSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;

  public HandleCeilingHitSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.GoingUp,
        GameMatcher.CharacterConfig,
        GameMatcher.CharacterBody2D,
        GameMatcher.CeilingHitSensorBackwardFar,
        GameMatcher.CeilingHitSensorBackward,
        GameMatcher.CeilingHitSensorForward,
        GameMatcher.CeilingHitSensorForwardFar)
    );
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      if (entity.CeilingHitSensorBackwardFar.IsColliding() && !entity.CeilingHitSensorBackward.IsColliding())
      {
        entity.CharacterBody2D.Position += Vector2.Right * entity.CharacterConfig.RunMaxSpeed * _timeService.DeltaTime;
      }
      else if (entity.CeilingHitSensorForwardFar.IsColliding() && !entity.CeilingHitSensorForward.IsColliding())
      {
        entity.CharacterBody2D.Position += Vector2.Left * entity.CharacterConfig.RunMaxSpeed * _timeService.DeltaTime;
      }
      else if (entity.CharacterBody2D.IsOnCeiling())
      {
        entity.ReplaceAirVelocity(0);
      }
    }
  }
}