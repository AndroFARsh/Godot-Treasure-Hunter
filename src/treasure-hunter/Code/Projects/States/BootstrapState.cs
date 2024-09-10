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

  public BootstrapState(IStateMachine stateMachine, 
    ICurtainService curtainService,
    ISaveLoadService saveLoadService,
    IStaticDataService staticDataService)
  {
    _stateMachine = stateMachine;
    _curtainService = curtainService;
    _saveLoadService = saveLoadService;
    _staticDataService = staticDataService;
  }

  protected override async void OnEnter()
  {
    _saveLoadService.InitializePersistentData();
    _staticDataService.LoadAll();
      
    await _curtainService.ShowCurtain();
    _stateMachine.Enter<LoadSplashState>();
  }
}