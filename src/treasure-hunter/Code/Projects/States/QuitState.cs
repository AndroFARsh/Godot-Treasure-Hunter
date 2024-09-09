using Code.Common.Curtains;
using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using Code.Levels;
using GodotTask;

namespace Code.Projects.States;

public class QuitState : NoPayloadState
{
  private readonly ISceneLoader _sceneLoader;
  private readonly ICurtainService _curtainService;
  private readonly IProject _project;

  public QuitState(ISceneLoader sceneLoader, ICurtainService curtainService, IProject project)
  {
    _sceneLoader = sceneLoader;
    _curtainService = curtainService;
    _project = project;
  }
    
  protected override async void OnEnter()
  {
    await _curtainService.ShowCurtain();
    _sceneLoader.UnloadAllScenes();
    _project.Quit();
  }
}