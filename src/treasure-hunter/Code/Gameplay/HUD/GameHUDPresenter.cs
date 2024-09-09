using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;

namespace Code.Gameplay.HUD;

public class GameHUDPresenter : IUiViewPresenter<GameHUDView>
{
  private readonly IWindowService _windowService;
  
  public GameHUDPresenter(IWindowService windowService) 
  {
    _windowService = windowService;
  }
    
  public void OnAttach(GameHUDView view)
  {
    view.Menu.Pressed += OnMenuClick;
  }
  
  public void OnDetach(GameHUDView view)
  {
    view.Menu.Pressed -= OnMenuClick;
  }
  
  private void OnMenuClick() => _windowService.Push(WindowName.GameMenuWindow);
}