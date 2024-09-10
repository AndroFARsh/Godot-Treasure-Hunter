using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Projects.States;

public class LoadLevelsState : NoPayloadState
{
  private const string LevelsScreenScenePath = "res://Scenes/Levels.tscn";
    
  private readonly IStateMachine _stateMachine;
  private readonly ISceneLoader _sceneLoader;

  public LoadLevelsState(IStateMachine stateMachine, ISceneLoader sceneLoader)
  {
    _stateMachine = stateMachine;
    _sceneLoader = sceneLoader;
  }

  protected override async void OnEnter()
  {
    _sceneLoader.UnloadAllScenes();
    await _sceneLoader.LoadSceneAsync(LevelsScreenScenePath);
    _stateMachine.Enter<LevelsState>();
  }
}