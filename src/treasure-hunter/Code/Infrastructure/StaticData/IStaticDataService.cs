using Code.Common.Curtains.Configs;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData;

public interface IStaticDataService
{
  CurtainConfig CurtainConfig { get; }
    
  WindowServiceConfig WindowServiceConfig { get; }
    
  int NumberOfLevels { get; }
  
  void LoadAll();

  WindowConfig GetWindowConfig(WindowName name);

  LevelConfig GetLevelConfig(int level);
}