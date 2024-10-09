using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.CharacterParticleEffects.Systems;

public class HandleLandParticleEffectSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _effectEntities;
  private readonly IGroup<GameEntity> _characterEntities;

  public HandleLandParticleEffectSystem(GameContext game)
  {
    _characterEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Character,
        GameMatcher.OnFloor,
        GameMatcher.PrevFrameInAir)
    );
    
    _effectEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.LandParticleEffect,
        GameMatcher.AnimatedSprite2D,
        GameMatcher.Node2D,
        GameMatcher.TargetId
      ));
  }

  public void Execute()
  {
    foreach (GameEntity character in _characterEntities)
    foreach (GameEntity effect in _effectEntities)
    {
      if (character.Id != effect.TargetId) continue;

      effect.Node2D.GlobalPosition = character.Node2D.GlobalPosition;
      effect.AnimatedSprite2D.Visible = true;
      effect.AnimatedSprite2D.Play("land");
    }
  }
}