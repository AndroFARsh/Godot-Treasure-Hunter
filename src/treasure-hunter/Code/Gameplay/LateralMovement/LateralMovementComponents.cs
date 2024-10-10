using Entitas;

namespace Code.Gameplay.LateralMovement;

[Game] public class LateralMovableComponent : IComponent { }
[Game] public class LateralVelocityComponent : IComponent { public float Value; }
[Game] public class LateralMaxSpeedComponent : IComponent { public float Value; }
[Game] public class AccelerationComponent : IComponent { public float Value; }
[Game] public class DecelerationComponent : IComponent { public float Value; }