using Godot;

namespace Code.Gameplay.Character.Configs;

[GlobalClass]
public partial class CharacterConfig : Resource
{
  [Export] public PackedScene Prefab;

  [ExportGroup("Gravity")]
  //Downwards force (gravity) needed for the desired jumpHeight and jumpTimeToApex.
  public float GravityStrength => 2 * JumpHeight / (JumpTimeToApex * JumpTimeToApex);

  //Multiplier to the player's gravityScale when falling.										  
  [Export] public float FallGravityMult = 1.5f;

  //Maximum fall speed (terminal velocity) of the player when falling.
  [Export] public float FallMaxSpeed = 400;

  //Larger multiplier to the player's gravityScale when they are falling and a downwards input is pressed.
  //Seen in games such as Celeste, lets the player fall extra fast if they wish.
  [Export] public float FallFastGravityMult = 2f;

  //Maximum fall speed(terminal velocity) of the player when performing a faster fall.									  
  [Export] public float FallFastMaxSpeed = 400;

  [ExportGroup("Run")]
  //Target speed we want the player to reach.
  [Export] public float RunMaxSpeed = 200;

  //The speed at which our player accelerates to max speed, can be set to runMaxSpeed for instant acceleration down to 0 for none at all
  [Export] public float RunAcceleration = 6;

  //The speed at which our player decelerates from their current speed, can be set to runMaxSpeed for instant deceleration down to 0 for none at all
  [Export] public float RunDeceleration = 10;

  //Multipliers applied to acceleration rate when airborne.
  [Export(PropertyHint.Range, "0f, 1")] public float InAirAccelerationMult = 0.9f;

  //Multipliers applied to decelerate rate when airborne.
  [Export(PropertyHint.Range, "0f, 1")] public float InAirDecelerationMult = 0.3f;

  [Export] public bool DoConserveMomentum = true;

  [ExportGroup("Ground Jump")]
  //Height of the player's jump
  [Export] public float JumpHeight = 64;

  //Time between applying the jump force and reaching the desired jump height. These values also control the player's gravity and jump force.
  [Export] public float JumpTimeToApex = 0.5f;

  //The initial jump velocity applied (upwards) to the player when they jump.
  public float JumpVelocity => -2 * JumpHeight / JumpTimeToApex;

  [ExportGroup("Air Jump")]
  //
  [Export]
  public int NumberOfAirJump = 1;

  [ExportGroup("Both Jumps")]
  //Multiplier to increase gravity if the player releases the jump button while still jumping
  [Export]
  public float JumpCutGravityMult = 2;

  //Reduces gravity while close to the apex (desired max height) of the jump
  [Export(PropertyHint.Range, "0f, 1")] public float JumpHangGravityMult = 0.1f;

  //Speeds (close to 0) where the player will experience extra "jump hang". The player's velocity.y is closest to 0 at the jump's apex (think of the gradient of a parabola or quadratic function)
  [Export(PropertyHint.Range, "0f, 1")] public float JumpHangTimeThreshold;
  [Export] public float JumpHangAccelerationMult;
  [Export] public float JumpHangMaxSpeedMult;

  [ExportGroup("Wall Jump")]
  //The actual force (this time set by us) applied to the player when wall jumping.
  [Export]
  public Vector2 WallJumpForce;

  //Reduces the effect of player's movement while wall jumping.
  [Export(PropertyHint.Range, "0f, 1")] public float WallJumpRunLerp;

  //Time after wall jumping the player's movement is slowed for.
  [Export(PropertyHint.Range, "0f, 1.5f")]
  public float WallJumpTime;

  //Player will rotate to face wall jumping direction
  [Export] public bool DoTurnOnWallJump;

  [ExportGroup("Slide")] [Export] public float SlideSpeed;
  [Export] public float SlideAcceleration;

  [ExportGroup("Assists")]
  //Grace period after falling off a platform, where you can still jump
  [Export(PropertyHint.Range, "0.01f, 0.5f")]
  public float CoyoteTime = 0.1f;

  //Grace period after pressing jump where a jump will be automatically performed once the requirements (eg. being grounded) are met.
  [Export(PropertyHint.Range, "0.01f, 0.5f")]
  public float JumpInputBufferTime = 0.1f;
}