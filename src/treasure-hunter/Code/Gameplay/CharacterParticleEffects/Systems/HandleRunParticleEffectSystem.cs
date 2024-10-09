using Entitas;

namespace Code.Gameplay.CharacterParticleEffects.Systems;

public class HandleRunParticleEffectSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _characterEntities;
  private readonly IGroup<GameEntity> _effectEntities;
  private readonly IGroup<InputEntity> _inputs;

  public HandleRunParticleEffectSystem(InputContext input, GameContext game)
  {
    _characterEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.Id,
        GameMatcher.Node2D,
        GameMatcher.LateralVelocity
      ));
    
    _inputs = input.GetGroup(
      InputMatcher.AllOf(InputMatcher.Character, InputMatcher.HorizontalDirection)
    );
    
    _effectEntities = game.GetGroup(
      GameMatcher.AllOf(
        GameMatcher.RunParticleEffect,
        GameMatcher.AnimatedSprite2D,
        GameMatcher.Node2D,
        GameMatcher.TargetId
        ));
  }

  public void Execute()
  {
    foreach (GameEntity character in _characterEntities)
    foreach (GameEntity effect in _effectEntities)
    foreach (InputEntity input in _inputs)
    {
      if (character.Id != effect.TargetId) continue;
      
      effect.Node2D.GlobalPosition = character.Node2D.GlobalPosition;
      effect.AnimatedSprite2D.Visible = character.isOnFloor && input.HorizontalDirection != 0;
      if (input.HorizontalDirection != 0)
        effect.ReplaceFacingFlip(input.HorizontalDirection < 0);
    }
  }
}