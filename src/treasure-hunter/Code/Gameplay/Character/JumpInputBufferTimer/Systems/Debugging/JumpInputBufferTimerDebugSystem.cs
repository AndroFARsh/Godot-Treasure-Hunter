using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.JumpInputBufferTimer.Systems.Debugging;

#if DEBUG

public class JumpInputBufferTimerDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public JumpInputBufferTimerDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.VisualDebugger2D,
        GameMatcher.CharacterBody2D
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      CharacterBody2D characterBody2D = entity.CharacterBody2D;
      entity.VisualDebugger2D.RequestDrawCircle(
        position: characterBody2D.Position,
        radius: 4,
        color: entity.hasJumpInputBufferTimer ? Colors.Green : Colors.Red,
        filled: true
      );
    }
  }
}

#endif
