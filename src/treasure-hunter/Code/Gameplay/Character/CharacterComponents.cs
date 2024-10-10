using Code.Gameplay.Character.Configs;
using Code.Gameplay.Common.Nodes;
using Entitas;
using Godot;

namespace Code.Gameplay.Character;

// Ground Jump
[Game] public class GroundJumpingComponent : IComponent { }
[Game] public class AirJumpNumberComponent : IComponent { public int Value; }
[Game] public class JustAirJumpComponent : IComponent { }

// Timers
[Game] public class JumpBufferInputTimerComponent : IComponent { public float Value; }
[Game] public class CoyoteTimerComponent : IComponent { public float Value; }
[Game] public class JumpApexHangTimerComponent : IComponent { public float Value; }

// Ceiling
[Game] public class CeilingHitSensorForwardFarComponent : IComponent { public RayCast2D Value; }
[Game] public class CeilingHitSensorForwardComponent : IComponent { public RayCast2D Value; }
[Game] public class CeilingHitSensorBackwardComponent : IComponent { public RayCast2D Value; }
[Game] public class CeilingHitSensorBackwardFarComponent : IComponent { public RayCast2D Value; }

// Character
[Game] public class LandEffectAnimator2DComponent : IComponent {  public LandEffectAnimator2D Value; }
[Game] public class CharacterConfigComponent : IComponent { public CharacterConfig Value; }



  


