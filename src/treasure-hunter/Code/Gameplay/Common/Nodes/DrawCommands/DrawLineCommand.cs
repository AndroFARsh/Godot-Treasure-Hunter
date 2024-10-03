using Godot;

namespace Code.Gameplay.Common.Nodes.DrawCommands;

public readonly struct DrawLineCommand : IDrawCommand
{
  private readonly Vector2 _from;
  private readonly Vector2 _to;
  private readonly Color _color;
  private readonly float _width;
  private readonly bool _antialiased;

  public DrawLineCommand(
    Vector2 from,
    Vector2 to,
    Color color,
    float width,
    bool antialiased)
  {
    _from = from;
    _to = to;
    _color = color;
    _width = width;
    _antialiased = antialiased;
  }

  public void Draw(Node2D node) => node.DrawLine(_from, _to, _color, _width, _antialiased);
}