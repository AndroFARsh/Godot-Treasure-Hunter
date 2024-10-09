using Code.Gameplay.CharacterParticleEffects.Configs;
using Godot;

namespace Code.Gameplay.Character.Configs;

[GlobalClass]
public partial class CharacterConfig : Resource
{
  [ExportGroup("Prefabs")] 
  [Export] public PackedScene Prefab;
  [Export] public ParticleEffectConfig[] EffectPrefabs;
  
  [ExportGroup("Land Squash Effect")] 
  [Export(PropertyHint.Range, "0f, 1")] public float LandSquashScaleFactor = 0.4f;
  [Export] public float LandSquashDuration = 0.1f;
  
  [ExportGroup("Gravity")]
  // Downwards force (gravity) needed for the desired jumpHeight and jumpTimeToApex.
  public float GravityStrength => 2 * JumpHeight / (JumpTimeToApex * JumpTimeToApex);

  [Export] public bool FallGravityScaleFeature = true;
  [Export] public float FallGravityScale = 1.5f;
  // Maximum fall speed (terminal velocity) of the player when falling.
  [Export] public float FallMaxSpeed = 400;

  [ExportGroup("Fall Fast Gravity")]
  [Export] public bool FallFastGravityScaleFeature = true;
  // Larger Scale to the player's gravity when they are falling and a downwards input is pressed.
  // Seen in games such as Celeste, lets the player fall extra fast if they wish.
  [Export] public float FallFastGravityScale = 2f;

  // Maximum fall speed(terminal velocity) of the player when performing a faster fall.									  
  [Export] public float FallFastMaxSpeed = 400;

  [ExportGroup("Run")]
  // Target speed we want the player to reach.
  [Export] public float RunMaxSpeed = 200;

  // The speed at which our player accelerates to max speed, can be set to runMaxSpeed for instant acceleration down to 0 for none at all
  [Export] public float RunAcceleration = 6;

  // The speed at which our player decelerates from their current speed, can be set to runMaxSpeed for instant deceleration down to 0 for none at all
  [Export] public float RunDeceleration = 10;

  // Scaleipliers applied to acceleration rate when airborne.
  [Export(PropertyHint.Range, "0f, 1")] public float InAirAccelerationScale = 0.9f;

  // Scaleipliers applied to decelerate rate when airborne.
  [Export(PropertyHint.Range, "0f, 1")] public float InAirDecelerationScale = 0.3f;

  [Export] public bool DoConserveMomentum = true;

  [ExportGroup("Ground Jump")]
  // Height of the player's jump
  [Export] public float JumpHeight = 64;

  // Time between applying the jump force and reaching the desired jump height. These values also control the player's gravity and jump force.
  [Export] public float JumpTimeToApex = 0.5f;

  // The initial jump velocity applied (upwards) to the player when they jump.
  public float JumpVelocity => -2 * JumpHeight / JumpTimeToApex;

  [ExportGroup("Air Jump")]
  // Height of the player's air jump
  [Export] public float AirJumpHeightScale = 0.75f;
  [Export] public int AirJumpNumber = 2;
  
  public float AirJumpHeight => JumpHeight * AirJumpHeightScale;
  public float AirJumpVelocity => JumpVelocity * AirJumpHeightScale;

  [ExportGroup("Both Jumps")]
  [Export] public bool JumpCutGravityScaleFeature = true;
  [Export] public float JumpCutGravityScale = 2;
  
  // Reduces gravity while close to the apex (desired max height) of the jump and jump button still pressed
  [Export] public bool JumpHangGravityScaleFeature = true;
  [Export] public float JumpHangGravityScale = 0.0f;
  [Export] public float JumpApexHangTime = 0.1f;
  
  [ExportGroup("Wall Jump")]
  //The actual force (this time set by us) applied to the player when wall jumping.
  [Export] public Vector2 WallJumpForce;

  //Reduces the effect of player's movement while wall jumping.
  [Export(PropertyHint.Range, "0f, 1")] public float WallJumpRunLerp;

  //Time after wall jumping the player's movement is slowed for.
  [Export(PropertyHint.Range, "0f, 1.5f")]
  public float WallJumpTime;

  //Player will rotate to face wall jumping direction
  [Export] public bool DoTurnOnWallJump;

  [ExportGroup("Slide")] 
  [Export] public float SlideSpeed;
  [Export] public float SlideAcceleration;

  [ExportGroup("Assists")]
  //Grace period after falling off a platform, where you can still jump
  [Export(PropertyHint.Range, "0.01f, 0.5f")] public float CoyoteTime = 0.1f;

  //Grace period after pressing jump where a jump will be automatically performed once the requirements (eg. being grounded) are met.
  [Export(PropertyHint.Range, "0.01f, 0.5f")] public float JumpInputBufferTime = 0.1f;
}