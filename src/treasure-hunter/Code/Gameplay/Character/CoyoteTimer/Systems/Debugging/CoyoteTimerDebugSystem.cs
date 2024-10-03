using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Character.CoyoteTimer.Systems.Debugging;

#if DEBUG
public class CoyoteTimerDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _entities;

  public CoyoteTimerDebugSystem(GameContext game)
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
        color: entity.hasCoyoteTimer ? Colors.Green : Colors.Red,
        filled: true
      );
    }
  }
}

#endif