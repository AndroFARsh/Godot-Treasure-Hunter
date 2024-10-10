using Entitas;

namespace Code.Gameplay.Gravity;

[Game] public class ApplyGravityComponent : IComponent { }
[Game] public class GravityStrengthComponent : IComponent { public float Value; }
[Game] public class GravityScaleComponent : IComponent { public float Value; }
[Game] public class FallMaxSpeedComponent : IComponent { public float Value; }

[Game] public class AirVelocityComponent : IComponent { public float Value; }
