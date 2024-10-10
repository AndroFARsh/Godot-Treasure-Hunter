using Entitas;

namespace Code.Gameplay.Gravity.Systems;

public class ResetGravityOnJustLendSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public ResetGravityOnJustLendSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.ApplyGravity,
      GameMatcher.AirVelocity,
      GameMatcher.PrevFrameInAir,
      GameMatcher.OnFloor
    ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.ReplaceAirVelocity(0);
  }
}