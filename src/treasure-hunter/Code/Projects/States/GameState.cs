using Code.Common.Curtains;
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

  // private GameplayFeature _feature;

  public GameState(
    InputContext input,
    GameContext game,
    ISystemFactory systemFactory, 
    ICurtainService curtainService)
  {
    _input = input;
    _game = game;
    _systemFactory = systemFactory;
    _curtainService = curtainService;
  }

  protected override void OnEnter()
  {
    // _feature = _systemFactory.Create<GameplayFeature>();
    // _feature.Initialize();
    //
    _curtainService.HideCurtain().Forget();
  }

  protected override void OnTick()
  {
    // _feature.Execute();
    // _feature.Cleanup();
  }

  protected override async GDTask OnExitAsync()
  {
    await _curtainService.ShowCurtain();
      
    // _feature.DeactivateReactiveSystems();
    // _feature.ClearReactiveSystems();

    MarkAllEntitiesReadyToDestroy();
      
    // _feature.TearDown();
    // _feature = null;
  }

  private void MarkAllEntitiesReadyToDestroy()
  {
    foreach (InputEntity entity in _input.GetEntities())
      entity.isReadyToCleanUp = true;
      
    foreach (GameEntity entity in _game.GetEntities())
      entity.isReadyToCleanUp = true;
  }
}