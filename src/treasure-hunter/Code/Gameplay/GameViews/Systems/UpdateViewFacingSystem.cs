using Entitas;
using Godot;

namespace Code.Gameplay.GameViews.Systems;

public class UpdateViewFacingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateViewFacingSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.FacingFlip, GameMatcher.AnimatedSprite2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.AnimatedSprite2D.FlipH = entity.FacingFlip;
  }
}