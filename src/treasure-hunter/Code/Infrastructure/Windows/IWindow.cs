using Code.Infrastructure.UI;

namespace Code.Infrastructure.Windows;

public interface IWindow : IUiView
{
  void Resume();
  void Pause();
}