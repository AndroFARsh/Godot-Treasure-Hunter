using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Systems;

public class PlatformSnappingSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public PlatformSnappingSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
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
      Vector2 characterPosition = character.Node2D.Position;
      Vector2 cameraPosition = camera.Node2D.Position;

      cameraPosition.Y = Mathf.Lerp(cameraPosition.Y, characterPosition.Y,
        camera.PositionSnappingSpeed * _timeService.DeltaTime);
      
      camera.Node2D.Position = cameraPosition;
    }
  }
}