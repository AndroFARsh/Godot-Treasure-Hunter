using System.Collections.Generic;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Jump.Systems;

public class GroundJumpSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();

  public GroundJumpSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.PerformGroundJump
      ));
  }
  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      entity.ReplaceAirVelocity(entity.JumpVelocity);
      entity.isPerformGroundJump = false;
    }
  }
}