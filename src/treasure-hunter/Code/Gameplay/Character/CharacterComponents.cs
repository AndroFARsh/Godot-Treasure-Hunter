using Code.Gameplay.Character.Configs;
using Entitas;

namespace Code.Gameplay.Character;

public enum State
{
  Idle,
  Run,
  Air
}

public enum AirSubState
{
  Rise,
  Fall,
  Land
}

[Game] public class StateComponent : IComponent { public State Value; }

[Game] public class AirSubStateComponent : IComponent { public State Value; }

[Game] public class CharacterComponent : IComponent { }

[Game] public class CharacterConfigComponent : IComponent { public CharacterConfig Value; }



  


