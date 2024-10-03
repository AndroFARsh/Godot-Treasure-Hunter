using Code.Levels.Configs;
using Code.StaticData;

namespace Code.Levels.Services
{
  public class LevelDataProvider : ILevelDataProvider
  {
    private readonly IStaticDataService _staticDataService;
    
    public int LevelIndex  { get; private set; }
    
    public string SceneName => LevelConfig.Name;
    
    public LevelConfig LevelConfig => _staticDataService.GetLevelConfig(LevelIndex);

    public LevelDataProvider(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public void SetCurrentLevel(int level) => LevelIndex = level;
  }
}