using Entitas;
using Godot;

namespace Code.Gameplay.Character;

[Game] public class ApplyGravityComponent : IComponent { }
[Game] public class GravityComponent : IComponent { public Vector2 Value; }
[Game] public class FallingComponent : IComponent { }
[Game] public class AirComponent : IComponent { }
[Game] public class GroundedComponent : IComponent { }
[Game] public class CoyoteTimerComponent : IComponent { public float Value; }

[Game] public class CharacterComponent : IComponent { }

[Game] public class FacingComponent : IComponent { public float Value; }

[Game] public class GroundAccelerationComponent : IComponent { public float Value; }
[Game] public class GroundDecelerationComponent : IComponent { public float Value; }
[Game] public class GroundMaxRunSpeedComponent : IComponent { public float Value; }

[Game] public class VelocityComponent : IComponent { public Vector2 Value; }

[Game] public class JumpForceComponent : IComponent { public float Value; }

[Game] public class CoyoteTimeComponent : IComponent { public float Value; }

[Game] public class BufferTimeComponent : IComponent { public float Value; }
  


