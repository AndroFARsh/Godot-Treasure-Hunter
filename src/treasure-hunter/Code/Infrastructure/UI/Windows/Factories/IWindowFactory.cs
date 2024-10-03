namespace Code.Infrastructure.UI.Windows.Factories;

public interface IWindowFactory
{
  IWindow CreateWindow(WindowName name);
}