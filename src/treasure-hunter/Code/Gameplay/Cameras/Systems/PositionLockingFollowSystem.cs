using Entitas;

namespace Code.Gameplay.Cameras.Systems;

public class PositionLockingFollowSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _character;
  private readonly IGroup<GameEntity> _cameras;

  public PositionLockingFollowSystem(GameContext game)
  {
    _character = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.Character, GameMatcher.Node2D));
    
    _cameras = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.PositionLocking, 
        GameMatcher.Camera2D, 
        GameMatcher.Node2D));
  }

  public void Execute()
  {
    foreach (GameEntity camera in _cameras)
    foreach (GameEntity character in _character)
    {
      camera.Node2D.Position = character.Node2D.Position;
    }
  }
}