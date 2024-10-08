using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.Systems.Debugging;

#if DEBUG
[Game] public class DebugGroundJumpPositionComponent : IComponent { public Vector2 Value; }

public class PlayerJumpHeightDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _positionEntities;
  private readonly IGroup<GameEntity> _visualEntities;
  
  public PlayerJumpHeightDebugSystem(GameContext game)
  {
    _positionEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.OnFloor,
        GameMatcher.CharacterBody2D));
    
    _visualEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.CharacterConfig,
        GameMatcher.DebugGroundJumpPosition,
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _positionEntities)
      entity.ReplaceDebugGroundJumpPosition(entity.CharacterBody2D.GlobalPosition);
    
    foreach (GameEntity entity in _visualEntities)
    {
      Vector2 from = entity.DebugGroundJumpPosition;
      Vector2 to = from + Vector2.Up * entity.CharacterConfig.JumpHeight;
      entity.VisualDebugger2D.RequestDrawLine(
        from: from,
        to: to,
        color: Colors.White,
        width: 1
      );
      entity.VisualDebugger2D.RequestDrawLine(
        from: to + Vector2.Left * 3,
        to: to + Vector2.Right * 3,
        color: Colors.White,
        width: 1
      );
    }
  }
}
#endif