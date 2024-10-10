using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Enemies.Systems;

public class UpdateLedgeSensorsSystem : ReactiveSystem<GameEntity>
{
  public UpdateLedgeSensorsSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.LedgeSensor2D.Added());

  protected override bool Filter(GameEntity entity) => entity.hasLedgeSensor2D && entity.hasEnemyConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
      entity.LedgeSensor2D.TargetPosition *= entity.EnemyConfig.JumpHeight * 0.9f;
  }
}