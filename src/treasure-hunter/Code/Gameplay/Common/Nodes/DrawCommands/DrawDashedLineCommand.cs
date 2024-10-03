using Godot;

namespace Code.Gameplay.Common.Nodes.DrawCommands;

public readonly struct DrawDashedLineCommand : IDrawCommand
{
  private readonly Vector2 _from;
  private readonly Vector2 _to;
  private readonly Color _color;
  private readonly float _width;
  private readonly float _dash;
  private readonly bool _aligned;
  private readonly bool _antialiased;

  public DrawDashedLineCommand(
    Vector2 from,
    Vector2 to,
    Color color,
    float width,
    float dash, 
    bool aligned,
    bool antialiased)
  {
    _from = from;
    _to = to;
    _color = color;
    _width = width;
    _dash = dash;
    _aligned = aligned;
    _antialiased = antialiased;
  }

  public void Draw(Node2D node) => node.DrawDashedLine(_from, _to, _color, _width, _dash, _aligned, _antialiased);
}