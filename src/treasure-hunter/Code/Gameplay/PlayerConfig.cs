// using Godot;
// using Godot.Collections;
//
// namespace Code.Gameplay;
//
// [GlobalClass]
// public partial class PlayerConfig : Resource
// {
//   [ExportGroup("Gravity")]
//   //Downwards force (gravity) needed for the desired jumpHeight and jumpTimeToApex.
//   public float GravityStrength; 
//
//   //Strength of the player's gravity as a multiplier of gravity (set in ProjectSettings/Physics2D).
//   //Also the value the player's rigidbody2D.gravityScale is set to.
//   public float GravityScale; 
//
//   //Multiplier to the player's gravityScale when falling.										  
//   [Export] public float FallGravityMult;
//
//   //Maximum fall speed (terminal velocity) of the player when falling.
//   [Export] public float MaxFallSpeed;
//
//   //Larger multiplier to the player's gravityScale when they are falling and a downwards input is pressed.
//   //Seen in games such as Celeste, lets the player fall extra fast if they wish.
//   [Export] public float FastFallGravityMult;
//
//   //Maximum fall speed(terminal velocity) of the player when performing a faster fall.									  
//   [Export] public float maxFastFallSpeed;
//
//   [ExportGroup("Run")]
//   //Target speed we want the player to reach.
//   [Export]
//   public float RunMaxSpeed;
//
//   //The speed at which our player accelerates to max speed, can be set to runMaxSpeed for instant acceleration down to 0 for none at all
//   [Export] public float RunAcceleration;
//
//   //The actual force (multiplied with speedDiff) applied to the player.
//   public float RunAccelerationAmount;
//
//   //The speed at which our player decelerates from their current speed, can be set to runMaxSpeed for instant deceleration down to 0 for none at all
//   [Export] public float RunDeceleration;
//
//   //Actual force (multiplied with speedDiff) applied to the player .
//   public float RunDecelerationAmount;
//
//   //Multipliers applied to acceleration rate when airborne.
//   [Export(PropertyHint.Range, "0f, 1")] public float InAirAcceleration;
//
//   //Multipliers applied to decelerate rate when airborne.
//   [Export(PropertyHint.Range, "0f, 1")] public float InAirDeceleration;
//
//   [Export] public bool DoConserveMomentum = true;
//
//   [ExportGroup("Jump")]
//   //Height of the player's jump
//   [Export]
//   public float JumpHeight;
//
//   //Time between applying the jump force and reaching the desired jump height. These values also control the player's gravity and jump force.
//   [Export] public float JumpTimeToApex;
//
//   //The actual force applied (upwards) to the player when they jump.
//   public float JumpForce;
//
//   [ExportGroup("Both Jumps")]
//   //Multiplier to increase gravity if the player releases thje jump button while still jumping
//   [Export]
//   public float JumpCutGravityMult;
//
//   //Reduces gravity while close to the apex (desired max height) of the jump
//   [Export(PropertyHint.Range, "0f, 1")] public float JumpHangGravityMult;
//
//   //Speeds (close to 0) where the player will experience extra "jump hang". The player's velocity.y is closest to 0 at the jump's apex (think of the gradient of a parabola or quadratic function)
//   [Export(PropertyHint.Range, "0f, 1")] public float JumpHangTimeThreshold;
//   [Export] public float JumpHangAccelerationMult;
//   [Export] public float JumpHangMaxSpeedMult;
//
//   [ExportGroup("Wall Jump")]
//   //The actual force (this time set by us) applied to the player when wall jumping.
//   [Export]
//   public Vector2 wallJumpForce;
//
//   //Reduces the effect of player's movement while wall jumping.
//   [Export(PropertyHint.Range, "0f, 1")] public float WallJumpRunLerp;
//
//   //Time after wall jumping the player's movement is slowed for.
//   [Export(PropertyHint.Range, "0f, 1.5f")]
//   public float WallJumpTime;
//
//   //Player will rotate to face wall jumping direction
//   [Export] public bool DoTurnOnWallJump;
//
//   [ExportGroup("Slide")] [Export] public float SlideSpeed;
//   [Export] public float SlideAcceleration;
//
//   [ExportGroup("Assists")]
//   //Grace period after falling off a platform, where you can still jump
//   [Export(PropertyHint.Range, "0.01f, 0.5f")]
//   public float CoyoteTime;
//
//   //Grace period after pressing jump where a jump will be automatically performed once the requirements (eg. being grounded) are met.
//   [Export(PropertyHint.Range, "0.01f, 0.5f")]
//   public float JumpInputBufferTime;
//
//
//   public override void _ValidateProperty(Dictionary property)
//   {
//     //Calculate gravity strength using the formula (gravity = 2 * jumpHeight / timeToJumpApex^2) 
//     GravityStrength = -(2 * JumpHeight) / (JumpTimeToApex * JumpTimeToApex);
//
//     //Calculate the rigidbody's gravity scale (ie: gravity strength relative to unity's gravity value, see project settings/Physics2D)
//     GravityScale = 1; //GravityStrength / Physics2D.gravity.y;
//
//     //Calculate are run acceleration & deceleration forces using formula: amount = ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
//     RunAccelerationAmount = (50 * RunAcceleration) / RunMaxSpeed;
//     RunDecelerationAmount = (50 * RunDeceleration) / RunMaxSpeed;
//
//     //Calculate jumpForce using the formula (initialJumpVelocity = gravity * timeToJumpApex)
//     JumpForce = -GravityStrength * JumpTimeToApex;
//
//     RunAcceleration = Mathf.Clamp(RunAcceleration, 0.01f, RunMaxSpeed);
//     RunDeceleration = Mathf.Clamp(RunDeceleration, 0.01f, RunMaxSpeed);
//   }
// }