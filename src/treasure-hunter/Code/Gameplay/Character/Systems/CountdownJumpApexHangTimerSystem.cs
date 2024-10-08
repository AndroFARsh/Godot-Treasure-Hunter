using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class CountdownJumpApexHangTimerSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();
  
  public CountdownJumpApexHangTimerSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _entities = game.GetGroup(GameMatcher.JumpApexHangTimer);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceJumpApexHangTimer(entity.JumpApexHangTimer - _timeService.DeltaTime);
      if (entity.JumpApexHangTimer <= 0)
        entity.RemoveJumpApexHangTimer();
    }
  }
}