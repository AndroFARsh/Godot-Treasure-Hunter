using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class UpdateViewFacingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateViewFacingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Facing, GameMatcher.FacingNode2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Vector2 scale = entity.FacingNode2D.Scale;
      scale.X = entity.Facing;
      entity.FacingNode2D.Scale = scale;
    }
  }
}