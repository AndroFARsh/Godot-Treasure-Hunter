using Code.Audio;
using Code.Audio.Services;
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
  private readonly IAudioService _audioService;

  private HomeFeature _feature;

  public HomeState(MetaContext meta, ISystemFactory systemFactory, ICurtainService curtainService, IAudioService audioService)
  {
    _meta = meta;
    _systemFactory = systemFactory;
    _curtainService = curtainService;
    _audioService = audioService;
  }

  protected override async void OnEnter()
  {
    _feature = _systemFactory.Create<HomeFeature>();
    _feature.Initialize();

    _audioService.PlayMusic(MusicName.HomeTheme);
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
    _feature.Dispose();
    _feature = null;
  }

  private void MarkAllEntitiesReadyToDestroy()
  {
    foreach (MetaEntity entity in _meta.GetEntities())
      entity.isReadyToCleanUp = true;
  }
}