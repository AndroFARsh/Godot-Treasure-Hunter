using Godot;

namespace Code.Gameplay.Common.Nodes.DrawCommands;

public readonly struct DrawRectCommand : IDrawCommand
{
  private readonly Rect2 _rect;
  private readonly Color _color;
  private readonly bool _filled;
  private readonly float _width;
  private readonly bool _antialiased;

  public DrawRectCommand(
    Rect2 rect,
    Color color,
    bool filled,
    float width,
    bool antialiased)
  {
    _rect = rect;
    _color = color;
    _filled = filled;
    _width = width;
    _antialiased = antialiased;
  }

  public void Draw(Node2D node) => node.DrawRect(_rect, _color, _filled, _width, _antialiased);
}