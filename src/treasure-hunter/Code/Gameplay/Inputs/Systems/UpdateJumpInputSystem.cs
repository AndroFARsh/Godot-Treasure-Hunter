using Entitas;
using Godot;

namespace Code.Gameplay.Inputs.Systems;

public class UpdateJumpInputSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _entities;

  public UpdateJumpInputSystem(InputContext input)
  {
    _entities = input.GetGroup(InputMatcher
      .AllOf(InputMatcher.Character));
  }

  public void Execute()
  {
    foreach (InputEntity entity in _entities)
    {
      entity.isJumpJustPressed = Input.IsActionJustPressed("Jump");
      entity.isJumpPressed = Input.IsActionPressed("Jump");
      entity.isJumpJustReleased = Input.IsActionJustReleased("Jump");
    }
  }
}