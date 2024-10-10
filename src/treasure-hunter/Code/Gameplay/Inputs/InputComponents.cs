using Entitas;

namespace Code.Gameplay.Inputs;

[Game, Input] public class CharacterComponent : IComponent { }

[Game, Input] public class LateralDirectionComponent : IComponent { public float Value; }

[Input] public class JumpJustPressedComponent : IComponent { }

[Input] public class JumpPressedComponent : IComponent { }

[Input] public class JumpJustReleasedComponent : IComponent { }