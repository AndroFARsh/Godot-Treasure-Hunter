using System.Collections.Generic;
using System.Linq;
using Code.Common.Curtains.Configs;
using Code.Common.Extensions;
using Code.Infrastructure.ResourceManagement;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData;

public class StaticDataService : IStaticDataService
{
  private readonly IResourcesProvider _resourcesProvider;
  private readonly Dictionary<WindowName, WindowConfig> _windows = new();
  private readonly List<LevelConfig> _levels = new();

  public CurtainConfig CurtainConfig { get; private set; }
  public WindowServiceConfig WindowServiceConfig { get; private set; }

  public int NumberOfLevels => _levels.Count;

  public StaticDataService(IResourcesProvider resourcesProvider)
  {
    _resourcesProvider = resourcesProvider;
  }

  public void LoadAll()
  {
    LoadCurtainConfig();
    LoadWindowServiceConfig();
    LoadLevelConfig();
  }
  
  private void LoadLevelConfig() =>
    _levels.AddRange(_resourcesProvider.LoadAll<LevelConfig>("res://Configs/Levels").OrderBy(c => c.Number));

  public WindowConfig GetWindowConfig(WindowName name) => _windows[name];
  public LevelConfig GetLevelConfig(int level) => _levels[level];

  private void LoadCurtainConfig() => 
    CurtainConfig = _resourcesProvider.Load<CurtainConfig>("res://Configs/Curtain/CurtainConfig.tres");

  private void LoadWindowServiceConfig()
  {
    WindowServiceConfig = _resourcesProvider.Load<WindowServiceConfig>("res://Configs/Windows/WindowServiceConfig.tres");
    _windows.AddRange(WindowServiceConfig.Windows.ToDictionary(c => c.Name));
  }
}