using Code.Audio;
using Code.Audio.Services;
using Code.Common.Curtains;
using Code.Gameplay;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using GodotTask;

namespace Code.Projects.States;

public class GameState : EndOfFrameNoPayloadState
{
  private readonly InputContext _input;
  private readonly GameContext _game;
  private readonly ISystemFactory _systemFactory;
  private readonly ICurtainService _curtainService;
  private readonly IAudioService _audioService;

  private Feature _feature;

  public GameState(
    InputContext input,
    GameContext game,
    ISystemFactory systemFactory, 
    ICurtainService curtainService,
    IAudioService audioService)
  {
    _input = input;
    _game = game;
    _systemFactory = systemFactory;
    _curtainService = curtainService;
    _audioService = audioService;
  }

  protected override void OnEnter()
  {
    _feature = _systemFactory.Create<GameplayFeature>();
    _feature.Initialize();
    
    _audioService.PlayMusic(MusicName.GameplayMainTheme);
    _curtainService.HideCurtain().Forget();
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
    foreach (InputEntity entity in _input.GetEntities())
      entity.isReadyToCleanUp = true;
      
    foreach (GameEntity entity in _game.GetEntities())
      entity.isReadyToCleanUp = true;
  }
}