using System.Collections.Generic;
using Code.Gameplay.Character.Configs;
using Entitas;

namespace Code.Gameplay.Character.JumpInputBufferTimer.Systems;

public class StartJumpInputBufferTimerSystem : ReactiveSystem<InputEntity>
{
  private readonly IGroup<GameEntity> _characters;

  public StartJumpInputBufferTimerSystem(InputContext input, GameContext game) : base(input)
  {
    _characters = game.GetGroup(
      GameMatcher
        .AllOf(
          GameMatcher.Air,
          GameMatcher.Falling,
          GameMatcher.CharacterConfig)
        .NoneOf(GameMatcher.JumpInputBufferTimer)
    );
  }

  protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
    context.CreateCollector(InputMatcher.JumpJustPressed.Added());

  protected override bool Filter(InputEntity entity) => entity.isJumpJustPressed;

  protected override void Execute(List<InputEntity> inputs)
  {
    foreach (InputEntity _ in inputs)
    foreach (GameEntity character in _characters)
    {
      CharacterConfig config = character.CharacterConfig;
      character.ReplaceJumpInputBufferTimer(config.JumpInputBufferTime);
    }
  }
}