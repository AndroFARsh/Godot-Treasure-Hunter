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
    context.CreateCollector(GameMatcher.JumpSensor2D.Added());

  protected override bool Filter(GameEntity entity) => entity.hasJumpSensor2D && entity.hasEnemyConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
    {
      entity.JumpSensor2D.TargetPosition *= entity.EnemyConfig.JumpLateralDistanceToApex;
      entity.JumpSensor2D.Position = new Vector2(entity.WallSensor2D.Position.X, -entity.EnemyConfig.JumpHeight * 0.9f);
    }
  }
}