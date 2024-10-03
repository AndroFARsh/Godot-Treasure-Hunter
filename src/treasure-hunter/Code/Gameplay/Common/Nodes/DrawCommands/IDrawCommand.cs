using Godot;

namespace Code.Gameplay.Common.Nodes.DrawCommands;

public interface IDrawCommand
{
  void Draw(Node2D node);
}