using Code.Gameplay.Cameras.Configs;
using Entitas;

namespace Code.Gameplay.Cameras.Systems;

public class EnableCameraFollowSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public EnableCameraFollowSystem(GameContext game)
  {
    _entities = game.GetGroup(GameMatcher
      .AllOf(GameMatcher.CameraFollowType));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      entity.isPositionLocking = entity.CameraFollowType == CameraFollowType.PositionLocking;
      entity.isHPositionLocking = entity.CameraFollowType == CameraFollowType.HPositionLocking;
      entity.isCameraWindow = entity.CameraFollowType == CameraFollowType.CameraWindow;
    }
  }
}