using Code.Audio.Services;
using Code.Common.Curtains;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.StaticData;
using Code.PersistentData.SaveLoad;

namespace Code.Projects.States;

public class BootstrapState : NoPayloadState
{
  private readonly IStateMachine _stateMachine;
  private readonly ICurtainService _curtainService;
  private readonly ISaveLoadService _saveLoadService;
  private readonly IStaticDataService _staticDataService;
  private readonly IAudioService _audioService;

  public BootstrapState(IStateMachine stateMachine, 
    ICurtainService curtainService,
    ISaveLoadService saveLoadService,
    IStaticDataService staticDataService,
    IAudioService audioService)
  {
    _stateMachine = stateMachine;
    _curtainService = curtainService;
    _saveLoadService = saveLoadService;
    _staticDataService = staticDataService;
    _audioService = audioService;
  }

  protected override async void OnEnter()
  {
    _saveLoadService.Initialize();
    _staticDataService.Initialize();
    _audioService.Initialize();
      
    await _curtainService.ShowCurtain();
    _stateMachine.Enter<LoadSplashState>();
  }
}