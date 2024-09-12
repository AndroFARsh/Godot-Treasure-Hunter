using Godot;

namespace Code.Gameplay.Character.Configs;

[GlobalClass]
public partial class CharacterConfig : Resource
{
  [Export] public PackedScene Prefab { get; private set; }
  [Export] public float RunSpeed { get; private set; } = 130.0f;
  [Export] public float JumpVelocity  { get; private set; } = -300.0f;
}