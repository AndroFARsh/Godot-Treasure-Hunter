using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Projects.Config;
using Code.Projects.States;

namespace Code.Home.UI.MainMenu;

public class MainMenuUiPresenter : IUiViewPresenter<MainMenuUiView>
{
  private readonly IStateMachine _stateMachine;
  private readonly IWindowService _windowService;
  private readonly IProjectConfig _projectConfig;
  
  public MainMenuUiPresenter(
    IStateMachine stateMachine, 
    IWindowService windowService, 
    IProjectConfig projectConfig)
  {
    _stateMachine = stateMachine;
    _windowService = windowService;
    _projectConfig = projectConfig;
  }
    
  public void OnAttach(MainMenuUiView view)
  {
    view.Title.Text = _projectConfig.Name;
    view.Version.Text = _projectConfig.Version;
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