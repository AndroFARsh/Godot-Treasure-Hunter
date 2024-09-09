using Code.Common.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Godot;

namespace Code.Common;

[Game, Meta, Input] public class IdComponent : IComponent { [PrimaryEntityIndex] public ulong Value; }
[Game, Meta, Input] public class ReadyToCleanUpComponent : IComponent { }
[Game, Meta, Input] public class SelfDestroyTimerComponent : IComponent { public double Value; }
[Game, Meta, Input] public class ViewComponent : IComponent { public IEntityView Value; }
[Game, Meta, Input] public class ViewPathComponent : IComponent { public string Value; }
[Game, Meta, Input] public class ViewPrefabComponent : IComponent { public PackedScene Value; }