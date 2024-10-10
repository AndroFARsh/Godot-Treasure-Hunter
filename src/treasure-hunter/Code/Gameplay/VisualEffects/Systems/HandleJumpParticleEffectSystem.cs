using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.VisualEffects.Systems;

public class HandleJumpParticleEffectSystem : ReactiveSystem<GameEntity>
{
  private readonly IGroup<GameEntity> _effectEntities;

  public HandleJumpParticleEffectSystem(GameContext game) : base(game)
  {
    _effectEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.JumpDustParticleEffect,
        GameMatcher.AnimatedSprite2D,
        GameMatcher.Node2D,
        GameMatcher.TargetId
      ));
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
    context.CreateCollector(GameMatcher.GoingUp.Added());

  protected override bool Filter(GameEntity entity) =>
    entity.isInAir &&
    entity.isPrevFrameOnFloor &&
    entity.isGoingUp &&
    entity.hasNode2D &&
    entity.hasId;

  protected override void Execute(List<GameEntity> characterEntities)
  {
    foreach (GameEntity character in characterEntities)
    foreach (GameEntity effect in _effectEntities)
    {
      if (character.Id != effect.TargetId) continue;

      effect.Node2D.GlobalPosition = character.Node2D.GlobalPosition;
      effect.AnimatedSprite2D.Visible = true;
      effect.AnimatedSprite2D.Play("jump");
      
      if (character.hasFacing)
        effect.ReplaceFacing(character.Facing);
    }
  }
}