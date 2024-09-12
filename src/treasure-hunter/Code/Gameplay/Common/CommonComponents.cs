using Entitas;
using Godot;

namespace Code.Gameplay.Common;

[Game] public class WorldPosition2DComponent : IComponent { public Vector2 Value; }

[Game] public class Node2DComponent : IComponent { public Node2D Value; }

[Game] public class AnimatedSprite2DComponent : IComponent { public AnimatedSprite2D Value; }

[Game] public class CollisionShape2DComponent : IComponent { public CollisionShape2D Value; }

[Game] public class CharacterBody2DComponent : IComponent { public CharacterBody2D Value; }

