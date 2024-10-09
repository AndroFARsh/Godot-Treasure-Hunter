using Code.Gameplay.Character.Configs;
using Entitas;
using Godot;

namespace Code.Gameplay.Character;

[Game] public class InAirComponent : IComponent { }
[Game] public class PrevFrameInAirComponent : IComponent { }

[Game] public class OnFloorComponent : IComponent { }
[Game] public class PrevFrameOnFloorComponent : IComponent { }

[Game] public class GoingUpComponent : IComponent { }
[Game] public class PrevFrameGoingUpComponent : IComponent { }
[Game] public class FallingComponent : IComponent { }
[Game] public class PrevFrameFallingComponent : IComponent { }

// Gravity
[Game] public class GravityScaleComponent : IComponent { public float Value; }

// Velocity
[Game] public class AirVelocityComponent : IComponent { public float Value; }
[Game] public class LateralVelocityComponent : IComponent { public float Value; }

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
[Game] public class CharacterComponent : IComponent { }
[Game] public class CharacterConfigComponent : IComponent { public CharacterConfig Value; }



  


