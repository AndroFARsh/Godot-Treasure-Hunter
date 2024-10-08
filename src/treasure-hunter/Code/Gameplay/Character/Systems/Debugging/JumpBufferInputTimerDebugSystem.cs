using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.Systems.Debugging;

#if DEBUG

public class JumpBufferInputTimerDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public JumpBufferInputTimerDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.JumpBufferInputTimer,
        GameMatcher.CharacterConfig,
        GameMatcher.CharacterBody2D,
        GameMatcher.VisualDebugger2D));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      Vector2 position = entity.CharacterBody2D.GlobalPosition;
      entity.VisualDebugger2D.RequestDrawCircle(
        position,
        4,
        color: new Color(Colors.Green.R, Colors.Green.G, Colors.Green.B, 0.5f),
        filled: true
      );
    }
  }
}
#endif