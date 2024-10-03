using System.Collections.Generic;
using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.Jump.Systems.Debugging;

#if DEBUG
public class JumpHeightDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly List<GameEntity> _buffer = new();

  public JumpHeightDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher.AllOf(
      GameMatcher.Character, 
      GameMatcher.VisualDebugger2D,
      GameMatcher.DebugGroundPosition,
      GameMatcher.CharacterConfig
    ));
  }
  public void Execute()
  {
    foreach (GameEntity entity in _entities.GetEntities(_buffer))
    {
      var config = entity.CharacterConfig;
      var from = entity.DebugGroundPosition;
      var to = entity.DebugGroundPosition + Vector2.Up * config.JumpHeight;
      
      entity.VisualDebugger2D.RequestDrawLine(
        from: from,
        to: to,
        color: Colors.White,
        width: 1
      );
      entity.VisualDebugger2D.RequestDrawLine(
        from: to + 10 * Vector2.Right,
        to: to + 10 * Vector2.Left,
        color: Colors.White,
        width: 1
      );
    }
  }
}
#endif