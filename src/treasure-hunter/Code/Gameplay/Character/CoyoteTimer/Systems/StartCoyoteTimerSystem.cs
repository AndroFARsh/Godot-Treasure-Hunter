using System.Collections.Generic;
using Code.Gameplay.Character.Configs;
using Entitas;

namespace Code.Gameplay.Character.CoyoteTimer.Systems;

public class StartCoyoteTimerSystem : ReactiveSystem<GameEntity>
{
  public StartCoyoteTimerSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.Grounded.Removed());

  protected override bool Filter(GameEntity entity) 
    => !entity.isGrounded && !entity.hasCoyoteTimer && entity.hasCharacterConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
    {
      CharacterConfig config = entity.CharacterConfig;
      entity.ReplaceCoyoteTimer(config.CoyoteTime);
    } 
  }
}