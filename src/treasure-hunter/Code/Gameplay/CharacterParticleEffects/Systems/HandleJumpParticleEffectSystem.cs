using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.CharacterParticleEffects.Systems;

public class HandleJumpParticleEffectSystem : ReactiveSystem<GameEntity>
{
  private readonly IGroup<GameEntity> _effectEntities;

  public HandleJumpParticleEffectSystem(GameContext game) : base(game)
  {
    _effectEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.JumpParticleEffect,
        GameMatcher.AnimatedSprite2D,
        GameMatcher.Node2D,
        GameMatcher.TargetId
      ));
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.GroundJumping.Added());

  protected override bool Filter(GameEntity entity) => entity.isGroundJumping && entity.hasNode2D && entity.hasId;

  protected override void Execute(List<GameEntity> characterEntities)
  {
    foreach (GameEntity character in characterEntities)
    foreach (GameEntity effect in _effectEntities)
    {
      if (character.Id != effect.TargetId) continue;

      effect.Node2D.GlobalPosition = character.Node2D.GlobalPosition;
      effect.AnimatedSprite2D.Visible = true;
      effect.AnimatedSprite2D.Play("jump");
    }
  }
}