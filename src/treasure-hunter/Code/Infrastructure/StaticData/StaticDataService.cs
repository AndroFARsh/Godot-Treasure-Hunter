using System;
using System.Collections.Generic;
using System.Linq;
using Code.Audio;
using Code.Audio.Configs;
using Code.Common.Curtains.Configs;
using Code.Common.Extensions;
using Code.Gameplay.Cameras.Configs;
using Code.Gameplay.Character.Configs;
using Code.Infrastructure.ResourceManagement;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData;

public class StaticDataService : IStaticDataService, IDisposable
{
  private readonly IResourcesProvider _resourcesProvider;
  private readonly Dictionary<WindowName, WindowConfig> _windows = new();
  private readonly Dictionary<EffectName, EffectConfig> _effects = new();
  private readonly Dictionary<MusicName, MusicConfig> _musics = new();
  private readonly List<LevelConfig> _levels = new();
  
  public CameraConfig CameraConfig { get; private set; }
  public CharacterConfig CharacterConfig { get; private set; }
  public AudioConfig AudioConfig { get; private set; }
  public CurtainConfig CurtainConfig { get; private set; }
  public WindowServiceConfig WindowServiceConfig { get; private set; }

  public int NumberOfLevels => _levels.Count;

  public StaticDataService(IResourcesProvider resourcesProvider)
  {
    _resourcesProvider = resourcesProvider;
  }

  public void Initialize()
  {
    LoadCurtainConfig();
    LoadWindowServiceConfig();
    LoadLevelConfig();
    LoadAudioConfig();
    LoadCharacterConfig();
    LoadCameraConfig();
  }

  public WindowConfig GetWindowConfig(WindowName name) => _windows[name];
  public LevelConfig GetLevelConfig(int level) => _levels[level];
  public MusicConfig GetMusicConfig(MusicName name) => _musics[name];
  public EffectConfig GetEffectConfig(EffectName name) => _effects[name];

  
  private void LoadAudioConfig() =>
    AudioConfig = _resourcesProvider.Load<AudioConfig>("res://Configs/Audio/AudioConfig.tres")
      .With(cfg => _effects.AddRange(cfg.Effects.ToDictionary(c => c.Name)))
      .With(cfg => _musics.AddRange(cfg.Musics.ToDictionary(c => c.Name)));

  private void LoadLevelConfig() =>
    _levels.AddRange(_resourcesProvider.LoadAll<LevelConfig>("res://Configs/Levels").OrderBy(c => c.Number));
  
  private void LoadCurtainConfig() => 
    CurtainConfig = _resourcesProvider.Load<CurtainConfig>("res://Configs/Curtain/CurtainConfig.tres");

  private void LoadWindowServiceConfig() =>
    WindowServiceConfig = _resourcesProvider.Load<WindowServiceConfig>("res://Configs/Windows/WindowServiceConfig.tres")
      .With(cfg => _windows.AddRange(cfg.Windows.ToDictionary(c => c.Name)));
  
  private void LoadCharacterConfig() =>
    CharacterConfig = _resourcesProvider.Load<CharacterConfig>("res://Configs/Characters/CaptainClownCharacterConfig.tres");
  
  private void LoadCameraConfig() =>
    CameraConfig = _resourcesProvider.Load<CameraConfig>("res://Configs/Cameras/CameraConfig.tres");

  public void Dispose()
  {
    CameraConfig?.Dispose();
    CharacterConfig?.Dispose();
    AudioConfig?.Dispose();
    CurtainConfig?.Dispose();
    WindowServiceConfig?.Dispose();

    foreach (WindowConfig window in _windows.Values) window.Dispose();
    _windows.Clear();
    
    foreach (EffectConfig effect in _effects.Values) effect.Dispose();
    _effects.Clear();
    
    foreach (MusicConfig music in _musics.Values) music.Dispose();
    _musics.Clear();
    
    foreach (LevelConfig levels in _levels) levels.Dispose();
    _levels.Clear();
  }
}