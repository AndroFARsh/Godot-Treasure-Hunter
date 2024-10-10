using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Enemies.Systems;

public class UpdateForwardSensorsSystem : ReactiveSystem<GameEntity>
{
  public UpdateForwardSensorsSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.ForwardSensor2D.Added());

  protected override bool Filter(GameEntity entity) => entity.hasForwardSensor2D && entity.hasEnemyConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
      entity.ForwardSensor2D.TargetPosition *= entity.EnemyConfig.JumpLateralDistanceToApex * 0.7f;
  }
}