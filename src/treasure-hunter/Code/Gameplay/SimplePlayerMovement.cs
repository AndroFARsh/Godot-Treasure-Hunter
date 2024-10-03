// using Godot;
//
// namespace Code.Gameplay;
//
// [GlobalClass]
// public partial class SimplePlayerMovement : CharacterBody2D
// {
//   [Export] public float JumpHeight = 32 * 3f;
//   [Export] public float JumpTimeToApex = 0.8f;
//   [Export] public float GravityStrength;
//   [Export] public float JumpForce;
//   
//   [Export] public float RunSpeed = 140;
//   
//   private Vector2 _initialPosition;
//
//   public override void _Ready()
//   {
//     GravityStrength = (2 * JumpHeight) / (JumpTimeToApex * JumpTimeToApex);
//     JumpForce = -GravityStrength * JumpTimeToApex;
//     
//     _initialPosition = Position;
//   }
//   
//   public override void _PhysicsProcess(double delta)
//   {
//     Vector2 velocity = Velocity;
//     if (!IsOnFloor())
//       velocity.Y += (float)(GravityStrength * delta);
//     else
//       velocity.Y = 0;
//
//     if (IsOnFloor() && Input.IsActionJustPressed("Jump"))
//     {
//       velocity.Y = JumpForce;
//     }
//
//     float direction = Input.GetAxis("MoveLeft", "MoveRight");
//     velocity.X = direction * RunSpeed * (float)delta;
//
//     Velocity = velocity;
//     MoveAndSlide();
//   }
//
//   public override void _Draw()
//   {
//     var from = _initialPosition;
//     var to = _initialPosition + Vector2.Up * JumpHeight;
//       
//     DrawLine(
//       from: from,
//       to: to,
//       color: Colors.White,
//       width: 1
//     );
//     DrawLine(
//       from: to + 10 * Vector2.Right,
//       to: to + 10 * Vector2.Left,
//       color: Colors.White,
//       width: 1
//     );
//   }
// }
//
// // created by Dawnosaur :D