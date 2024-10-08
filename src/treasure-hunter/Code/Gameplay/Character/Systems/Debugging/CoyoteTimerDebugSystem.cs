using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.Systems.Debugging;

#if DEBUG

public class CoyoteTimerDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public CoyoteTimerDebugSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.InAir,
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
        2,
        color: entity.hasCoyoteTimer ? Colors.Green : Colors.Red,
        filled: true
      );
    }
  }
}
#endif