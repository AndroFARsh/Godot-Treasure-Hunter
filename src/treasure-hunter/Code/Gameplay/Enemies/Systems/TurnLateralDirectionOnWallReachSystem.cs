using Entitas;
using Godot;

namespace Code.Gameplay.Enemies.Systems;

public class TurnLateralDirectionOnWallReachSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
 
  public TurnLateralDirectionOnWallReachSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Enemy,
        GameMatcher.CharacterBody2D,
        GameMatcher.LateralDirection,
        GameMatcher.TurnOnWallReach,
        GameMatcher.OnFloor
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Vector2 moveDirection = Vector2.Right * entity.LateralDirection;
      CharacterBody2D body = entity.CharacterBody2D;
      if (body.IsOnWall() && body.GetWallNormal().Dot(moveDirection) < 0) 
      {
        entity.ReplaceLateralDirection(-entity.LateralDirection);
      }
    }
  }
}