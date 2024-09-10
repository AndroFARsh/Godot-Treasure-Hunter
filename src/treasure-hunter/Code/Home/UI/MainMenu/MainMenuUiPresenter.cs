using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Projects.Settings;
using Code.Projects.States;

namespace Code.Home.UI.MainMenu;

public class MainMenuUiPresenter : IUiViewPresenter<MainMenuUiView>
{
  private readonly IStateMachine _stateMachine;
  private readonly IWindowService _windowService;
  private readonly IProjectSettings _projectSettings;
  
  public MainMenuUiPresenter(
    IStateMachine stateMachine, 
    IWindowService windowService, 
    IProjectSettings projectSettings)
  {
    _stateMachine = stateMachine;
    _windowService = windowService;
    _projectSettings = projectSettings;
  }
    
  public void OnAttach(MainMenuUiView view)
  {
    view.Title.Text = _projectSettings.Name;
    view.Version.Text = _projectSettings.Version;
    view.Play.Pressed += OnPlayClick;
    view.Settings.Pressed += OnSettingsClick;
    view.Quit.Pressed += OnQuitClick;
  }
  
  public void OnDetach(MainMenuUiView view)
  {
    view.Play.Pressed -= OnPlayClick;
    view.Settings.Pressed -= OnSettingsClick;
    view.Quit.Pressed -= OnQuitClick;
  }
  
  private void OnPlayClick() => _stateMachine.Enter<LoadLevelsState>();

  private void OnQuitClick() => _stateMachine.Enter<QuitState>();
    
  private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);
}