using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CountdownJumpBufferInputTimerSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();
  
  public CountdownJumpBufferInputTimerSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.JumpBufferInputTimer);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceJumpBufferInputTimer(entity.JumpBufferInputTimer - _timeService.DeltaTime);
      if (entity.JumpBufferInputTimer <= 0)
        entity.RemoveJumpBufferInputTimer();
    }
  }
}