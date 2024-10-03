using Entitas;

namespace Code.Gameplay.LateralMove;

[Game] public class MovableComponent : IComponent { }

[Game] public class FacingComponent : IComponent { public float Value; }

[Game] public class LateralVelocityComponent : IComponent { public float Value; }

[Game] public class LateralDirectionComponent : IComponent { public float Value; }

[Game] public class DoConserveMomentumComponent : IComponent { }
[Game] public class AccelerationComponent : IComponent { public float Value; }
[Game] public class MaxSpeedComponent : IComponent { public float Value; }
[Game] public class DecelerationComponent : IComponent { public float Value; }
