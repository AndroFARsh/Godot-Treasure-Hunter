using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.JumpInputBufferTimer.Systems;

public class CountDownJumpInputBufferTimerSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly ITimeService _timeService;
  
  private readonly List<GameEntity> _buffer = new(1);

  public CountDownJumpInputBufferTimerSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.JumpInputBufferTimer);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceJumpInputBufferTimer(entity.JumpInputBufferTimer - _timeService.DeltaTime);
      if (entity.JumpInputBufferTimer <= 0)
        entity.RemoveJumpInputBufferTimer();
    }
  }
}