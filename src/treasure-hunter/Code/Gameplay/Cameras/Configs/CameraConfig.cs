using Godot;

namespace Code.Gameplay.Cameras.Configs;

[GlobalClass]
public partial class CameraConfig : Resource
{
  [Export] public PackedScene Prefab { get; private set; }

  [Export] public CameraFollowType FollowType;
  [Export] public SnappingType SnappingType;
  
  [Export] public float SnappingSpeed = 100;
  [Export] public Rect2 CameraWindow = new(-100, -50, 200, 100);
}