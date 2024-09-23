using Entitas;

namespace Code.Gameplay.Inputs.Systems;

public class CleanupJumpInputSystem : ICleanupSystem
{
  private readonly IGroup<InputEntity> _entities;

  public CleanupJumpInputSystem(InputContext input)
  {
    _entities = input.GetGroup(InputMatcher
      .AllOf(InputMatcher.Character));
  }

  public void Cleanup()
  {
    foreach (InputEntity entity in _entities)
    {
      entity.isJumpJustPressed = false;
      entity.isJumpJustReleased = false;
    }
  }
}