using Godot;

namespace Code.Gameplay.Enemies.Configs;

[GlobalClass]
public partial class EnemyConfig : Resource
{
  [Export] public EnemyName Name;
  [Export] public PackedScene Prefab;

  public float GravityStrength => 2 * JumpHeight / (JumpTimeToApex * JumpTimeToApex);
  [Export] public float FallMaxSpeed = 400f;
  
  
  [Export] public float JumpHeight = 48;
  [Export] public float JumpTimeToApex = 0.35f; 
  public float JumpVelocity => -2 * JumpHeight / JumpTimeToApex;
  public float JumpLateralDistanceToApex => RunMaxSpeed * JumpTimeToApex;
  
  [Export] public float RunMaxSpeed = 80;
  [Export] public float RunAcceleration = 10;
  [Export] public float RunDeceleration = 10;
}