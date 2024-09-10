using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Projects.Settings;
using Code.Projects.States;

namespace Code.SettingsWindow
{
  public class SettingsWindowPresenter : IUiViewPresenter<SettingsWindowView>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly IProjectSettings _settings;

    private SettingsWindowView _view;
    
    public SettingsWindowPresenter(
      IWindowService windowService, 
      IStateMachine stateMachine,
      IProjectSettings settings)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _settings = settings;
    }
    
    public void OnAttach(SettingsWindowView view)
    {
      _view = view;
      _view.Music.Value = _settings.MusicVolume;
      _view.Effect.Value = _settings.EffectVolume;
      
      _view.Credits.Pressed += OnCreditsClick;
      _view.Save.Pressed += OnSaveClick;
      _view.Back.Pressed += OnBackClick;
    }

    public void OnDetach(SettingsWindowView view)
    {
      _view.Credits.Pressed -= OnCreditsClick;
      _view.Save.Pressed -= OnSaveClick;
      _view.Back.Pressed -= OnBackClick;
      
      _view = null;
    }

    private void OnCreditsClick()
    {
      _stateMachine.Enter<LoadCreditsState>();
      _windowService.Pop();
    } 
    
    private void OnBackClick()
    {
      _windowService.Pop();
    }

    private void OnSaveClick()
    {
      _settings.MusicVolume = (float)_view.Music.Value;
      _settings.EffectVolume = (float)_view.Effect.Value;
      _settings.Save();
      
      _windowService.Pop();
    }
  }
}