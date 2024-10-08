using Entitas;

namespace Code.Gameplay.Character.Systems;

public class UpdateFacingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly IGroup<InputEntity> _inputs;

  public UpdateFacingSystem(InputContext input, GameContext game)
  {
    _inputs = input.GetGroup(
      InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection)
    );
    _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Character));
  }

  public void Execute()
  {
    foreach (InputEntity input in _inputs)
    foreach (GameEntity entity in _entities)
    {
      if (input.HorizontalDirection != 0)
        entity.ReplaceFacingFlip(input.HorizontalDirection < 0);
    }
  }
}