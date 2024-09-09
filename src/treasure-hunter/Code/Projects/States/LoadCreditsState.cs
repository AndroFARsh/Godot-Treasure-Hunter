using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Projects.States;

public class LoadCreditsState : NoPayloadState
{
  private const string CreditsScreenScenePath = "res://Scenes/Credits.tscn";
    
  private readonly IStateMachine _stateMachine;
  private readonly ISceneLoader _sceneLoader;

  public LoadCreditsState(IStateMachine stateMachine, ISceneLoader sceneLoader)
  {
    _stateMachine = stateMachine;
    _sceneLoader = sceneLoader;
  }

  protected override async void OnEnter()
  { 
    _sceneLoader.UnloadAllScenes();
    await _sceneLoader.LoadSceneAsync(CreditsScreenScenePath);
    _stateMachine.Enter<CreditsState>();
  }
}