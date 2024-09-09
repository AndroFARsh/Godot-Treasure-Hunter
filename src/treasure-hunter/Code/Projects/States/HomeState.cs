using Code.Common.Curtains;
using Code.Home;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using GodotTask;

namespace Code.Projects.States;

public class HomeState : EndOfFrameNoPayloadState
{
  private readonly MetaContext _meta;
  private readonly ISystemFactory _systemFactory;
  private readonly ICurtainService _curtainService;

  private HomeFeature _feature;

  public HomeState(MetaContext meta, ISystemFactory systemFactory, ICurtainService curtainService)
  {
    _meta = meta;
    _systemFactory = systemFactory;
    _curtainService = curtainService;
  }

  protected override async void OnEnter()
  {
    _feature = _systemFactory.Create<HomeFeature>();
    _feature.Initialize();

    await GDTask.Delay(2000);
      
    await _curtainService.HideCurtain();
  }

  protected override void OnTick()
  {
    _feature.Execute();
    _feature.Cleanup();
  }

  protected override async GDTask OnExitAsync()
  {
    await _curtainService.ShowCurtain();
      
    _feature.DeactivateReactiveSystems();
    _feature.ClearReactiveSystems();

    MarkAllEntitiesReadyToDestroy();
      
    _feature.TearDown();
    _feature = null;
  }

  private void MarkAllEntitiesReadyToDestroy()
  {
    foreach (MetaEntity entity in _meta.GetEntities())
      entity.isReadyToCleanUp = true;
  }
}