using Entitas;
using Godot;

namespace Code.Gameplay.LateralMove.Systems;

public class UpdateFacingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateFacingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.LateralDirection);
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      float horizontalDirection = entity.LateralDirection;
      if (Mathf.Abs(horizontalDirection) > float.Epsilon)
        entity.ReplaceFacing(Mathf.Sign(horizontalDirection));
    }
  }
}