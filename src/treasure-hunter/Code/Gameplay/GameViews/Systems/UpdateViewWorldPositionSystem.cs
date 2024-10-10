using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class UpdateViewWorldPositionSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateViewWorldPositionSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf( 
        GameMatcher.WorldPosition2D,
        GameMatcher.Node2D
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.Node2D.GlobalPosition = entity.WorldPosition2D;
      entity.RemoveWorldPosition2D();
    }
  }
}