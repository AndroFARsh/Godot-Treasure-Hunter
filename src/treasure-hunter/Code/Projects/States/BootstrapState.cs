using Code.Audio.Services;
using Code.Common.Curtains;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Levels.Services;
using Code.PersistentData.SaveLoad;
using Code.StaticData;

namespace Code.Projects.States;

public class BootstrapState : NoPayloadState
{
  private readonly IStateMachine _stateMachine;
  private readonly ICurtainService _curtainService;
  private readonly ISaveLoadService _saveLoadService;
  private readonly IStaticDataService _staticDataService;
  private readonly IAudioService _audioService;
  private readonly ILevelDataProvider _levelDataProvider;

  public BootstrapState(IStateMachine stateMachine, 
    ICurtainService curtainService,
    ISaveLoadService saveLoadService,
    IStaticDataService staticDataService,
    IAudioService audioService,
    ILevelDataProvider levelDataProvider)
  {
    _stateMachine = stateMachine;
    _curtainService = curtainService;
    _saveLoadService = saveLoadService;
    _staticDataService = staticDataService;
    _audioService = audioService;
    _levelDataProvider = levelDataProvider;
  }

  protected override async void OnEnter()
  {
    _saveLoadService.Initialize();
    _staticDataService.Initialize();
    _audioService.Initialize();
      
    await _curtainService.ShowCurtain();
    
#if !DEBUG    
    _stateMachine.Enter<LoadSplashState>();
#else
    _levelDataProvider.SetCurrentLevel(0);
    _stateMachine.Enter<LoadGameState>();
#endif
  }
}