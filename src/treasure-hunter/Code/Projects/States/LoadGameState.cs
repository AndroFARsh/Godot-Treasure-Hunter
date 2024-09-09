using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Levels.Services;

namespace Code.Projects.States;

public class LoadGameState : NoPayloadState
{
  private const string GameScreenScenePath = "res://Scenes/Game.tscn";
  
  private readonly IStateMachine _stateMachine;
  private readonly ISceneLoader _sceneLoader;

  public LoadGameState(IStateMachine stateMachine, ISceneLoader sceneLoader)
  {
    _stateMachine = stateMachine;
    _sceneLoader = sceneLoader;
  }

  protected override async void OnEnter()
  {
    _sceneLoader.UnloadAllScenes();
    await _sceneLoader.LoadSceneAsync(GameScreenScenePath);
    _stateMachine.Enter<GameState>();
  }
}