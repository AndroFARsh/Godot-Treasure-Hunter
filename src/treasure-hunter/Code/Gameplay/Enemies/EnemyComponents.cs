using Code.Gameplay.Enemies.Configs;
using Entitas;
using Godot;

namespace Code.Gameplay.Enemies;

[Game] public class EnemyComponent : IComponent { }
  
[Game] public class EnemyNameComponent : IComponent { public EnemyName Value; }

[Game] public class EnemyConfigComponent : IComponent { public EnemyConfig Value; }

[Game] public class JumpVelocityComponent : IComponent { public float Value; }

// Enemy AI
[Game] public class TurnOnWallReachComponent : IComponent { }
[Game] public class TurnOnLedgeReachComponent : IComponent { }
[Game] public class JumpOnLedgeIfReachComponent : IComponent { }

[Game] public class ForwardSensor2DComponent : IComponent { public RayCast2D Value; }
[Game] public class LedgeSensor2DComponent : IComponent { public RayCast2D Value; }
[Game] public class JumpHeightSensor2DComponent : IComponent { public RayCast2D Value; }