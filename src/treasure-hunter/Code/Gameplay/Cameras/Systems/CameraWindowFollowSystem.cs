using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Systems;

public class CameraWindowFollowSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public CameraWindowFollowSystem(GameContext game)
  {
    _character = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.Node2D));

    _cameras = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.CameraWindow,
        GameMatcher.Camera2D,
        GameMatcher.Node2D));
  }

  public void Execute()
  {
    foreach (GameEntity camera in _cameras)
    foreach (GameEntity character in _character)
    {
      Rect2 cameraRect = camera.CameraWindowRect;
      cameraRect.Position += camera.Node2D.Position;

      Vector2 characterPosition = character.Node2D.Position;
      Vector2 deltaPosition = new(
        CalculateDeltaPosition(characterPosition.X, cameraRect.Position.X, cameraRect.Size.X),
        CalculateDeltaPosition(characterPosition.Y, cameraRect.Position.Y, cameraRect.Size.Y)
      );
      camera.Node2D.Position += deltaPosition;
    }
  }

  private static float CalculateDeltaPosition(float pos, float rectPos, float rectSize)
  {
    if (pos < rectPos) return pos - rectPos;
    if (pos > rectPos + rectSize) return pos - (rectPos + rectSize);
    return 0;
  }
}