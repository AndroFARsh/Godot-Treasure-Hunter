using Code.Gameplay.Character.Animation;
using Code.Gameplay.Character.CoyoteTimer;
using Code.Gameplay.Character.Jump;
using Code.Gameplay.Character.JumpInputBufferTimer;
using Code.Gameplay.Character.Lateral;
using Code.Gameplay.Character.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Character;

public sealed class CharacterFeature : Feature
{
  public CharacterFeature(ISystemFactory systems)
  {
    Add(systems.Create<InitCharacterSystem>());

    Add(systems.Create<CoyoteTimerFeature>());
    Add(systems.Create<JumpInputBufferTimerFeature>());
    
    Add(systems.Create<LateralFeature>());
    Add(systems.Create<JumpFeature>());
    
    Add(systems.Create<AnimationFeature>());
  }
}