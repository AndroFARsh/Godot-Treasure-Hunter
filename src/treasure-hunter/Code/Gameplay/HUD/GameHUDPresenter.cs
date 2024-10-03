using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Windows;
using Code.Infrastructure.UI.Windows.Services;

namespace Code.Gameplay.HUD;

public class GameHUDPresenter : IUiViewPresenter
{
  private readonly IWindowService _windowService;
  
  public GameHUDPresenter(IWindowService windowService) 
  {
    _windowService = windowService;
  }

  public bool IsSupported(IUiView view) => view is GameHUDView;

  public void OnAttach(IUiView v)
  {
    if (v is not GameHUDView view) return;
    view.Menu.Pressed += OnMenuClick;
  }
  
  public void OnDetach(IUiView v)
  {
    if (v is not GameHUDView view) return;
    view.Menu.Pressed -= OnMenuClick;
  }
  
  private void OnMenuClick() => _windowService.Push(WindowName.GameMenuWindow);
}