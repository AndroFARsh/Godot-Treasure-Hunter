using Godot;

namespace Code.Infrastructure.UI.Windows;

public interface IWindow : IUiView
{
  Node Node { get; }
  void Resume();
  void Pause();
}