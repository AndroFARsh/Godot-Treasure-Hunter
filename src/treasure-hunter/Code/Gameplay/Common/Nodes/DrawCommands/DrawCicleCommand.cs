using Godot;

namespace Code.Gameplay.Common.Nodes.DrawCommands;

public readonly struct DrawCircleCommand : IDrawCommand
{
  private readonly Vector2 _position;
  private readonly float _radius;
  private readonly Color _color;
  private readonly bool _filled;
  private readonly float _width;
  private readonly bool _antialiased;

  public DrawCircleCommand(
    Vector2 position,
    float radius,
    Color color,
    bool filled,
    float width,
    bool antialiased)
  {
    _position = position;
    _radius = radius;
    _color = color;
    _filled = filled;
    _width = width;
    _antialiased = antialiased;
  }

  public void Draw(Node2D node) => 
    node.DrawCircle(_position, _radius, _color, _filled, _width, _antialiased);
}