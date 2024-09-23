using Code.Infrastructure.Time;
using Entitas;

namespace Code.Gameplay.Character.Systems;

public class UpdateGravityVectorSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public UpdateGravityVectorSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.CharacterBody2D, GameMatcher.ApplyGravity));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
      entity.ReplaceGravity(entity.CharacterBody2D.GetGravity());
  }
}