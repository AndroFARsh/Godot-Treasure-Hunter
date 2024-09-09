namespace Code.Levels.Services
{
  public interface ILevelDataProvider
  {
    // string SceneName { get; }
    
    int LevelIndex { get; }

    // LevelConfig LevelConfig { get; }
    
    void SetCurrentLevel(int level);
  }
}