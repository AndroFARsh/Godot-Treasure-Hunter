using Entitas;
using Godot;

namespace Code.Gameplay.GameViews;

[Game] public class FacingComponent : IComponent { public float Value; }
[Game] public class FacingNode2DComponent : IComponent { public Node2D Value; }

[Game] public class VelocityComponent : IComponent { public Vector2 Value; }

