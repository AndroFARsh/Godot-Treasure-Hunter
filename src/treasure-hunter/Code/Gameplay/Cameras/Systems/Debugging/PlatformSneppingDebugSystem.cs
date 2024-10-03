using Entitas;
using Entitas.Godot;
using Godot;

namespace Code.Gameplay.Cameras.Systems.Debugging;

#if DEBUG
public class PlatformSnappingDebugSystem : IExecuteSystem, IDebugSystem
{
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public PlatformSnappingDebugSystem(GameContext game)
  {
    _character = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.Node2D, GameMatcher.Grounded));

    _cameras = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.PlatformSnapping,
        GameMatcher.PositionSnappingSpeed,
        GameMatcher.Camera2D,
        GameMatcher.Node2D));
  }

  public void Execute()
  {
    foreach (GameEntity camera in _cameras)
    foreach (GameEntity character in _character)
    {
      Camera2D camera2D = camera.Camera2D;
      Node2D character2D = character.Node2D;
      camera.VisualDebugger2D.RequestDrawLine(
        from: new Vector2(camera2D.LimitLeft, character2D.Position.Y),
        to: new Vector2(camera2D.LimitRight, character2D.Position.Y),
        color: Colors.White,
        width: 2
      );
    }
  }
}
#endif