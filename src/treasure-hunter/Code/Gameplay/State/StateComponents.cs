using Entitas;

namespace Code.Gameplay.State;


[Game] public class InAirComponent : IComponent { }
[Game] public class PrevFrameInAirComponent : IComponent { }

[Game] public class OnFloorComponent : IComponent { }
[Game] public class PrevFrameOnFloorComponent : IComponent { }

[Game] public class GoingUpComponent : IComponent { }
[Game] public class PrevFrameGoingUpComponent : IComponent { }
[Game] public class FallingComponent : IComponent { }
[Game] public class PrevFrameFallingComponent : IComponent { }
