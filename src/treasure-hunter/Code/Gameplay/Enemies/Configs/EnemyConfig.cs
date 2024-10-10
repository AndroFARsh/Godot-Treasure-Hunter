using Godot;

namespace Code.Gameplay.Enemies.Configs;

[GlobalClass]
public partial class EnemyConfig : Resource
{
  [Export] public EnemyName Name;
  [Export] public PackedScene Prefab;

  [Export] public float RunMaxSpeed = 80;  
  
  [Export] public float JumpHeight = 64;
  [Export] public float JumpTimeToApex = 0.5f;
  
  public float GravityStrength => 2 * JumpHeight / (JumpTimeToApex * JumpTimeToApex);
 
  [Export] public float FallMaxSpeed = 400f;
}