// using Godot;
//
// namespace TreasureHunter.Code.Common.Extensions
// {
//   public static class TransformExtensions
//   {
//     public static Transform2D SetWorldXY(this Transform2D transform, float x, float y)
//     {
//       transform.Origin = new Vector2(x, y);
//       return transform;
//     }
//
//     public static Transform2D SetWorldX(this Transform2D transform, float x)
//     {
//       transform.Origin.X = x;
//       return transform;
//     }
//
//     public static Transform2D AddWorldX(this Transform2D transform, float x)
//     {
//       transform.Origin.X += x;
//       return transform;
//     }
//
//     public static Transform2D SetLocalX(this Transform2D transform, float x)
//     {
//       transform.localPosition = transform.localPosition.SetX(x);
//       return transform;
//     }
//
//     public static Transform LocalScaleX(this Transform transform, float x)
//     {
//       transform.localScale = transform.localScale.SetX(x);
//       return transform;
//     }
//     
//     public static Transform LocalScaleY(this Transform transform, float y)
//     {
//       transform.localScale = transform.localScale.SetY(y);
//       return transform;
//     }
//     
//     public static void SetScaleX(this Transform t, float scale) =>
//       t.localScale = new Vector3(scale, t.localScale.y, t.localScale.z);
//
//     public static Transform AddLocalX(this Transform transform, float x)
//     {
//       transform.localPosition = transform.localPosition.AddX(x);
//       return transform;
//     }
//
//     public static Transform SetWorldY(this Transform transform, float y)
//     {
//       transform.position = transform.position.SetY(y);
//       return transform;
//     }
//
//     public static Transform AddWorldY(this Transform transform, float y)
//     {
//       transform.position = transform.position.AddY(y);
//       return transform;
//     }
//
//     public static Transform SetLocalY(this Transform transform, float y)
//     {
//       transform.localPosition = transform.localPosition.SetY(y);
//       return transform;
//     }
//
//     public static Transform AddLocalY(this Transform transform, float y)
//     {
//       transform.localPosition = transform.localPosition.AddX(y);
//       return transform;
//     }
//   }
// }