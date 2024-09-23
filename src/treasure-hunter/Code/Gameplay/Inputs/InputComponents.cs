using Entitas;

namespace Code.Gameplay.Inputs;

[Input] public class CharacterComponent : IComponent { }

[Input] public class HorizontalDirectionComponent : IComponent { public float Value; }

[Input] public class JumpJustPressedComponent : IComponent { }

[Input] public class JumpPressedComponent : IComponent { }

[Input] public class JumpJustReleasedComponent : IComponent { }