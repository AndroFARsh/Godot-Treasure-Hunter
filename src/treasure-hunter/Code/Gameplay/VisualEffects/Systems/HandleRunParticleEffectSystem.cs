using Entitas;

namespace Code.Gameplay.VisualEffects.Systems;

public class HandleRunParticleEffectSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _characterEntities;
  private readonly IGroup<GameEntity> _effectEntities;

  public HandleRunParticleEffectSystem(GameContext game)
  {
    _characterEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Id,
        GameMatcher.Node2D,
        GameMatcher.LateralVelocity,
        GameMatcher.Facing
      ));
    
    _effectEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.RunDustParticleEffect,
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
      effect.AnimatedSprite2D.Visible = character.isOnFloor && character.LateralDirection != 0;
      
      effect.ReplaceFacing(character.Facing);
    }
  }
}