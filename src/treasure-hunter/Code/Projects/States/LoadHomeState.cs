using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Projects.States;

public class LoadHomeState : NoPayloadState
{
  private const string HomeScreenScenePath = "res://Scenes/Home.tscn";
    
  private readonly IStateMachine _stateMachine;
  private readonly ISceneLoader _sceneLoader;

  public LoadHomeState(IStateMachine stateMachine, ISceneLoader sceneLoader)
  {
    _stateMachine = stateMachine;
    _sceneLoader = sceneLoader;
  }

  protected override async void OnEnter()
  { 
    _sceneLoader.UnloadAllScenes();
    await _sceneLoader.LoadSceneAsync(HomeScreenScenePath);
    _stateMachine.Enter<HomeState>();
  }
}