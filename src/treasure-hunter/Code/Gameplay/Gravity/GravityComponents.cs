using Entitas;

namespace Code.Gameplay.Gravity;


[Game] public class ApplyGravityComponent : IComponent { }

// State Flag that used to check is character on the air or on the ground
// next two flags are opposite, isAir == !isGround
[Game] public class AirComponent : IComponent { }
[Game] public class GroundedComponent : IComponent { }

// Substate flags for an Air state
[Game] public class RisingComponent : IComponent { }
[Game] public class FallingComponent : IComponent { }
[Game] public class LandingComponent : IComponent { }

// Gravity
[Game] public class GravityComponent : IComponent { public float Value; }
[Game] public class GravityScaleComponent : IComponent { public float Value; }
[Game] public class AirVelocityComponent : IComponent { public float Value; }



