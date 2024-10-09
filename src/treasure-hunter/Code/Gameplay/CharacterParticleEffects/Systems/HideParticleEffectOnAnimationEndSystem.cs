using Entitas;

namespace Code.Gameplay.CharacterParticleEffects.Systems;

public class HideParticleEffectOnAnimationEndSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;

  public HideParticleEffectOnAnimationEndSystem(GameContext game)
  {
    _entities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.ParticleEffect,
        GameMatcher.AnimatedSprite2D
      ));
  }

  public void Execute()
  {
    foreach (GameEntity entity in _entities)
    {
      if (!entity.AnimatedSprite2D.IsPlaying())
        entity.AnimatedSprite2D.Visible = false;
    }
  }
}