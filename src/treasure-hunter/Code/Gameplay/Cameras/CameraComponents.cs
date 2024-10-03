using Code.Gameplay.Cameras.Configs;
using Entitas;
using Godot;

namespace Code.Gameplay.Cameras;

[Game] public class Camera2DComponent : IComponent { public Camera2D Value; }

[Game] public class CameraFollowTypeComponent : IComponent { public CameraFollowType Value; }

[Game] public class PositionLockingComponent : IComponent { }

[Game] public class HPositionLockingComponent : IComponent { }

[Game] public class CameraWindowComponent : IComponent { }

[Game] public class SnappingTypeComponent : IComponent { public SnappingType Value; }

[Game] public class PositionSnappingComponent : IComponent { }

[Game] public class PlatformSnappingComponent : IComponent { }

[Game] public class CameraWindowRectComponent : IComponent { public Rect2 Value; }

[Game] public class PositionSnappingSpeedComponent : IComponent { public float Value; }


