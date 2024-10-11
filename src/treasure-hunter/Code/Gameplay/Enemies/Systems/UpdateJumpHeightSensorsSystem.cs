using System.Collections.Generic;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class UpdateJumpHeightSensorsSystem : ReactiveSystem<GameEntity>
{
  public UpdateJumpHeightSensorsSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.JumpHeightSensor2D.Added());

  protected override bool Filter(GameEntity entity) => entity.hasJumpHeightSensor2D && entity.hasEnemyConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
    {
      entity.JumpHeightSensor2D.TargetPosition *= entity.EnemyConfig.JumpLateralDistanceToApex;
      entity.JumpHeightSensor2D.Position = new Vector2(entity.JumpHeightSensor2D.Position.X, -entity.EnemyConfig.JumpHeight * 0.9f);
    }
  }
}