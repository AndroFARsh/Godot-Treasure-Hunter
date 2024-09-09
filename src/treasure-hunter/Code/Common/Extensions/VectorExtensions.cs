using Godot;

namespace Code.Common.Extensions
{
  public static class VectorExtensions
  {
    public static Vector3 SetX(this Vector3 v, float x)
    {
      Vector3 tmp = v;
      tmp.X = x;
      v = tmp;
      return v;
    }

    public static Vector3 SetY(this Vector3 v, float y)
    {
      Vector3 tmp = v;
      tmp.Y = y;
      v = tmp;
      return v;
    }

    public static Vector3 SetZ(this Vector3 v, float z)
    {
      Vector3 tmp = v;
      tmp.Z = z;
      v = tmp;
      return v;
    }

    public static Vector2 SetX(this Vector2 v, float x)
    {
      Vector2 tmp = v;
      tmp.X = x;
      v = tmp;
      return v;
    }

    public static Vector2 SetY(this Vector2 v, float y)
    {
      Vector2 tmp = v;
      tmp.Y = y;
      v = tmp;
      return v;
    }

    public static Vector3 AddX(this Vector3 v, float xDelta)
    {
      Vector3 tmp = v;
      tmp.X += xDelta;
      v = tmp;
      return v;
    }

    public static Vector3 AddY(this Vector3 v, float yDelta)
    {
      Vector3 tmp = v;
      tmp.Y += yDelta;
      v = tmp;
      return v;
    }

    public static Vector2 AddX(this Vector2 v, float xDelta)
    {
      Vector2 tmp = v;
      tmp.X += xDelta;
      v = tmp;
      return v;
    }

    public static Vector2 AddY(this Vector2 v, float yDelta)
    {
      Vector2 tmp = v;
      tmp.Y += yDelta;
      v = tmp;
      return v;
    }
  }
}