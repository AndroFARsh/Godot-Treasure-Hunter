using Entitas;
using Godot;

namespace Code.Gameplay.Cameras.Systems;

public class HPositionLockingFollowSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public HPositionLockingFollowSystem(GameContext game)
  {
    _character = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.Node2D));
    
    _cameras = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.HPositionLocking, 
        GameMatcher.Camera2D, 
        GameMatcher.Node2D));
  }

  public void Execute()
  {
    foreach (GameEntity camera in _cameras)
    foreach (GameEntity character in _character)
    {
      Vector2 cameraPosition = camera.Node2D.Position;
      cameraPosition.X = character.Node2D.Position.X;
      camera.Node2D.Position = cameraPosition;
    }
  }
}