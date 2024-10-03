using System.Collections.Generic;
using Code.Gameplay.Common.Nodes.DrawCommands;
using Godot;

namespace Code.Gameplay.Common.Nodes;

[GlobalClass]
public partial class VisualDebugger2D : Node2D
{
  private const float CleanDelay = 0.1f;
  
  private List<IDrawCommand> _drawCommands = new();
  private float _cleanTimer;
  private bool _delayedRefresh;

  public override void _Draw()
  {
    foreach (IDrawCommand command in _drawCommands)
      command.Draw(this);

    _delayedRefresh = _drawCommands.Count > 0; 
    _cleanTimer = _delayedRefresh ? CleanDelay : 0;
    _drawCommands.Clear();
  }

  public override void _Process(double delta)
  {
    _cleanTimer -= (float)delta;
    if (_delayedRefresh && _cleanTimer <= 0)
      QueueRedraw();
  }

  public void RequestDrawLine(Vector2 from, Vector2 to, Color color, float width = -1f, bool antialiased = false)
    => RequestDraw(new DrawLineCommand(from, to, color, width, antialiased));

  public void RequestDrawDashedLine(Vector2 from, Vector2 to, Color color, float width = -1f, float dash = 2f,
    bool aligned = true, bool antialiased = false)
    => RequestDraw(new DrawDashedLineCommand(from, to, color, width, dash, aligned, antialiased));

  public void RequestDrawRect(Rect2 rect, Color color, bool filled = false, float width = -1f, bool antialiased = false)
    => RequestDraw(new DrawRectCommand(rect, color, filled, width, antialiased));

  public void RequestDrawCircle(Vector2 position, float radius,  Color color, bool filled = false, float width = -1f, bool antialiased = false)
    => RequestDraw(new DrawCircleCommand(position, radius, color, filled, width, antialiased));
  
  public void RequestDraw(IDrawCommand command)
  {
    _cleanTimer = float.MaxValue;
    _drawCommands.Add(command);
    QueueRedraw();
  }

  public void Clear()
  {
    _drawCommands.Clear();
    QueueRedraw();
  }
}