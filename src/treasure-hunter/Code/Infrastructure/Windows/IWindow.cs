using Code.Infrastructure.UI;
using Godot;

namespace Code.Infrastructure.Windows;

public interface IWindow : IUiView
{
  Node Node { get; }
  void Resume();
  void Pause();
}