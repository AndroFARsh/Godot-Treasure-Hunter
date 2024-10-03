using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Windows;
using Code.Infrastructure.UI.Windows.Services;
using Code.Projects.Providers.Root;
using Code.Projects.Settings;
using Code.Projects.States;

namespace Code.Home.UI.MainMenu;

public class MainMenuUiPresenter : IUiViewPresenter
{
  private readonly IStateMachine _stateMachine;
  private readonly IWindowService _windowService;
  private readonly IProjectSettings _projectSettings;
  private readonly IRootProvider _rootProvider;

  public MainMenuUiPresenter(
    IStateMachine stateMachine, 
    IWindowService windowService, 
    IProjectSettings projectSettings,
    IRootProvider rootProvider)
  {
    _stateMachine = stateMachine;
    _windowService = windowService;
    _projectSettings = projectSettings;
    _rootProvider = rootProvider;
  }

  public bool IsSupported(IUiView view) => view is MainMenuUiView;

  public void OnAttach(IUiView v)
  {
    if (v is not MainMenuUiView view) return;
    
    view.Title.Text = _projectSettings.Name;
    view.Version.Text = _projectSettings.Version;
    view.Play.Pressed += OnPlayClick;
    view.Settings.Pressed += OnSettingsClick;
    view.Quit.Pressed += OnQuitClick;
  }
  
  public void OnDetach(IUiView v)
  {
    if (v is not MainMenuUiView view) return;
    
    view.Play.Pressed -= OnPlayClick;
    view.Settings.Pressed -= OnSettingsClick;
    view.Quit.Pressed -= OnQuitClick;
  }
  
  private void OnPlayClick() => _stateMachine.Enter<LoadLevelsState>();

  private void OnQuitClick() => _rootProvider.Quit();
    
  private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);
}