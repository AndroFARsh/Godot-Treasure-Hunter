using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.CoyoteTimer.Systems;

public class CountDownCoyoteTimerSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly ITimeService _timeService;
  
  private readonly List<GameEntity> _buffer = new(1);

  public CountDownCoyoteTimerSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.CoyoteTimer);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceCoyoteTimer(entity.CoyoteTimer - _timeService.DeltaTime);
      if (entity.CoyoteTimer <= 0 || entity.isGrounded)
        entity.RemoveCoyoteTimer();
    }
  }
}