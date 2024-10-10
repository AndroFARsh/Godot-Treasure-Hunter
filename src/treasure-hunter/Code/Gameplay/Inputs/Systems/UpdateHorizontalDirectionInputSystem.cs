using Entitas;
using Godot;

namespace Code.Gameplay.Inputs.Systems;

public class UpdateHorizontalDirectionInputSystem : IExecuteSystem
{
  private readonly IGroup<InputEntity> _entities;

  public UpdateHorizontalDirectionInputSystem(InputContext input)
  {
    _entities = input.GetGroup(
      InputMatcher.AllOf(
        InputMatcher.Character,
        InputMatcher.LateralDirection
      ));
  }

  public void Execute()
  {
    foreach (InputEntity entity in _entities)
    {
      float direction = Input.GetAxis("MoveLeft", "MoveRight");
      entity.ReplaceLateralDirection(direction);
    }
  }
}