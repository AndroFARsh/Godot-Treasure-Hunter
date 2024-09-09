using Code.Infrastructure.PersistentData;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.Configs;
using Code.Levels.Services;
using Code.Projects.States;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonUiPresenter : IUiViewPresenter<LevelButtonUiView>
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStateMachine _stateMachine;

    public LevelButtonUiPresenter(
      IStaticDataService staticDataService, 
      IPersistentDataProvider persistentDataProvider, 
      ILevelDataProvider levelDataProvider,
      IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _persistentDataProvider = persistentDataProvider;
      _levelDataProvider = levelDataProvider;
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(LevelButtonUiView view)
    {
      LevelConfig levelConfig = _staticDataService.GetLevelConfig(view.Level);
      view.Button.Text = levelConfig.Name;
      view.Button.Pressed += () => { OnLevelButtonClick(levelConfig.Number); };
      view.Button.Disabled = levelConfig.Number > _persistentDataProvider.ProgressData.LastUnlockedLevel;
    }

    public void OnDetach(LevelButtonUiView view)
    {
    }

    private void OnLevelButtonClick(int level)
    {
      _levelDataProvider.SetCurrentLevel(level);
      _stateMachine.Enter<LoadGameState>();
    }
  }
}