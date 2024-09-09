using Godot;
using GodotTask;

namespace Code.Infrastructure.UI;

public interface IWindowRoot
{
  Control Content { get; }

  GDTask ShowBackground();
  GDTask HideBackground();
}