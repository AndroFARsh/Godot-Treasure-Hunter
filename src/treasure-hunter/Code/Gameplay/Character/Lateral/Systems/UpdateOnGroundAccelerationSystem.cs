using System.Collections.Generic;
using Code.Gameplay.Character.Configs;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Lateral.Systems;

public class UpdateOnGroundAccelerationSystem : ReactiveSystem<GameEntity>
{
  public UpdateOnGroundAccelerationSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.Grounded.Added());

  protected override bool Filter(GameEntity entity) => entity.isCharacter && entity.hasCharacterConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
    {
      CharacterConfig config = entity.CharacterConfig;
      entity.ReplaceAcceleration(config.RunAcceleration);
      entity.ReplaceDeceleration(config.RunDeceleration);
    }
  }
}