using Godot;

namespace Code.Gameplay.Character.Configs;

[GlobalClass]
public partial class CharacterConfig : Resource
{
  [Export] public PackedScene Prefab { get; private set; }
  
  [Export] public float GroundAcceleration { get; private set; } = 250.0f;
  [Export] public float GroundRunSpeed { get; private set; } = 130.0f;
  [Export] public float GroundDeceleration { get; private set; } = 250.0f;
  
  // Time during what character still could make a jump even if there is no more ground
  [Export] public float CoyoteTime  { get; private set; } = 1.0f;
  [Export] public float BufferTime  { get; private set; } = 1.0f;
  [Export] public float JumpForce  { get; private set; } = -300.0f;
  
  
  [Export] public float MaxFallSpeed  { get; private set; } = 300.0f;
}