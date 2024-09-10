using Code.Audio;
using Code.Audio.Services;
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Projects.Settings;
using Code.Projects.States;
using Godot;

namespace Code.SettingsWindow
{
  public class SettingsWindowPresenter : IUiViewPresenter<SettingsWindowView>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly IProjectSettings _settings;
    private readonly IAudioService _audioService;

    private SettingsWindowView _view;
    
    public SettingsWindowPresenter(
      IWindowService windowService, 
      IStateMachine stateMachine,
      IProjectSettings settings,
      IAudioService audioService)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _settings = settings;
      _audioService = audioService;
    }
    
    public void OnAttach(SettingsWindowView view)
    {
      _view = view;
      
      _view.General.ValueChanged += OnGeneralValueChanged;
      _view.General.Value = _settings.GeneralVolume;

      _view.Music.ValueChanged += OnMusicValueChanged;
      _view.Music.Value = _settings.MusicVolume;
      
      _view.Effect.ValueChanged += OnEffectValueChanged; 
      _view.Effect.Value = _settings.EffectVolume;
      
      _view.Credits.Pressed += OnCreditsClick;
      _view.Save.Pressed += OnSaveClick;
      _view.Back.Pressed += OnBackClick;
    }

    public void OnDetach(SettingsWindowView view)
    {
      _view.General.ValueChanged -= OnGeneralValueChanged;
      _view.Music.ValueChanged -= OnMusicValueChanged;
      _view.Effect.ValueChanged -= OnEffectValueChanged; 
      
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
      _view.General.Value = _settings.GeneralVolume;
      _view.Music.Value = _settings.MusicVolume;
      _view.Effect.Value = _settings.EffectVolume;

      _windowService.Pop();
    }

    private void OnSaveClick()
    {
      _settings.GeneralVolume = (float)_view.General.Value;
      _settings.MusicVolume = (float)_view.Music.Value;
      _settings.EffectVolume = (float)_view.Effect.Value;
      
      _settings.Save();
      
      _windowService.Pop();
    }

    private void OnGeneralValueChanged(double value) => _audioService.SetVolume(AudioBus.General, (float)Mathf.Clamp(value, 0, 1));
    
    private void OnMusicValueChanged(double value) => _audioService.SetVolume(AudioBus.Music, (float)Mathf.Clamp(value, 0, 1));
    
    private void OnEffectValueChanged(double value) => _audioService.SetVolume(AudioBus.Effect, (float)Mathf.Clamp(value, 0, 1));
  }
}