using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.Configs;
using Code.Levels.Services;
using Code.PersistentData;
using Code.Projects.States;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonUiPresenter : IUiViewPresenter
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
    
    public bool IsSupported(IUiView view) => view is LevelButtonUiView;
    
    public void OnAttach(IUiView v)
    {
      if (v is not LevelButtonUiView view) return;
      
      LevelConfig levelConfig = _staticDataService.GetLevelConfig(view.Level);
      view.Button.Text = levelConfig.Name;
      view.Button.Pressed += () => { OnLevelButtonClick(levelConfig.Number); };
      view.Button.Disabled = levelConfig.Number > _persistentDataProvider.ProgressData.LastUnlockedLevel;
    }

    public void OnDetach(IUiView v)
    {
    }

    private void OnLevelButtonClick(int level)
    {
      _levelDataProvider.SetCurrentLevel(level);
      _stateMachine.Enter<LoadGameState>();
    }
  }
}