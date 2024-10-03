using System.Collections.Generic;
using Code.Gameplay.Character.Configs;
using Entitas;
using Godot;

namespace Code.Gameplay.Character.Lateral.Systems;

public class UpdateOnAirAccelerationSystem : ReactiveSystem<GameEntity>
{
  public UpdateOnAirAccelerationSystem(GameContext game) : base(game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.Air.Added());

  protected override bool Filter(GameEntity entity) => entity.isCharacter && entity.hasCharacterConfig;

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (GameEntity entity in entities)
    {
      CharacterConfig config = entity.CharacterConfig;
      entity.ReplaceAcceleration(config.RunAcceleration * config.InAirAccelerationMult);
      entity.ReplaceDeceleration(config.RunDeceleration * config.InAirDecelerationMult);
    }
  }
}