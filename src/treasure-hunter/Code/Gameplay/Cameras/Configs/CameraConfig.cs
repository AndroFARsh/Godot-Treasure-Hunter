using Godot;

namespace Code.Gameplay.Cameras.Configs;

[GlobalClass]
public partial class CameraConfig : Resource
{
  [Export] public PackedScene Prefab { get; private set; }
}