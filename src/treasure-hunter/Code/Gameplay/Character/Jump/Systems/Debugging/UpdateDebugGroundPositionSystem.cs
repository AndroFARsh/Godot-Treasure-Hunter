using System.Collections.Generic;
using Entitas;
using Entitas.Godot;

namespace Code.Gameplay.Character.Jump.Systems.Debugging;

#if DEBUG
public class UpdateDebugGroundPositionSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();

  public UpdateDebugGroundPositionSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.Grounded,
      GameMatcher.VisualDebugger2D,
      GameMatcher.Node2D
      ));
  }
  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
      entity.ReplaceDebugGroundPosition(entity.Node2D.Position);
  }
}
#endif