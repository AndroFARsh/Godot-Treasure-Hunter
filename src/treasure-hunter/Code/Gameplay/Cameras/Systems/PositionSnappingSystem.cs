using Code.Infrastructure.Time;
using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Systems;

public class PositionSnappingSystem : IExecuteSystem
{
  private readonly ITimeService _timeService;
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public PositionSnappingSystem(GameContext game, ITimeService timeService)
  {
    _timeService = timeService;
    _character = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.Node2D));

    _cameras = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.PositionSnapping,
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

      camera.Node2D.Position = cameraPosition.Lerp(characterPosition, camera.PositionSnappingSpeed * _timeService.DeltaTime);
    }
  }
}