using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Projects.States;

namespace Code.Gameplay.Windows.MenuWindow
{
  public class GameMenuWindowPresenter : IUiViewPresenter<GameMenuWindowView>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;

    public GameMenuWindowPresenter(IWindowService windowService, IStateMachine stateMachine, ITimeService timeService)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
    }
    
    public void OnAttach(GameMenuWindowView view)
    {
      view.Resume.Pressed += OnResumeClick;
      view.Settings.Pressed += OnSettingsClick;
      view.MainMenu.Pressed += OnMainMenuClick;
      
      _timeService.Pause();
    }
    
    public void OnDetach(GameMenuWindowView view)
    {
      _timeService.Resume();
      
      view.Resume.Pressed -= OnResumeClick;
      view.Settings.Pressed -= OnSettingsClick;
      view.MainMenu.Pressed -= OnMainMenuClick;

    }

    private void OnMainMenuClick()
    {
      // TODO: move to ECS
      _stateMachine.Enter<LoadHomeState>();
      _windowService.Pop();
    }

    private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);

    private void OnResumeClick()
    {
      _windowService.Pop();
    }
  }
}