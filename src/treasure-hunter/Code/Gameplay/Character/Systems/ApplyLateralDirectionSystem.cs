using Entitas;

namespace Code.Gameplay.Character.Systems;

public class ApplyLateralDirectionSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public ApplyLateralDirectionSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Character, InputMatcher.LateralDirection));
    _entities = game.GetGroup(GameMatcher.Character);
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      float direction = input.LateralDirection;
      entity.ReplaceLateralDirection(direction);
    }
  }
}