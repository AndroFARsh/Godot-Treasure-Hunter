using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CountdownCoyoteTimerSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly ITimeService _timeService;
  
  private readonly List<GameEntity> _buffer = new(1);

  public CountdownCoyoteTimerSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.CoyoteTimer);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceCoyoteTimer(entity.CoyoteTimer - _timeService.DeltaTime);
      if (entity.CoyoteTimer <= 0)
        entity.RemoveCoyoteTimer();
    }
  }
}