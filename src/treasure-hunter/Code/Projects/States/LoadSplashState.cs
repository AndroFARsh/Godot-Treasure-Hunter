using Code.Common.Curtains;
using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using GodotTask;

namespace Code.Projects.States;

public class LoadSplashState : NoPayloadState
{
  private const string SplashScreenScenePath = "res://Scenes/Splash.tscn";

  private readonly ICurtainService _curtainService;
  private readonly IStateMachine _stateMachine;
  private readonly ISceneLoader _sceneLoader;

  public LoadSplashState(ICurtainService curtainService, IStateMachine stateMachine, ISceneLoader sceneLoader)
  {
    _curtainService = curtainService;
    _stateMachine = stateMachine;
    _sceneLoader = sceneLoader;
  }

  protected override async void OnEnter()
  { 
    await _sceneLoader.LoadSceneAsync(SplashScreenScenePath);
    await _curtainService.HideCurtain();
    await GDTask.Delay(5000);
    await _curtainService.ShowCurtain();
    _stateMachine.Enter<LoadHomeState>();
  }
}