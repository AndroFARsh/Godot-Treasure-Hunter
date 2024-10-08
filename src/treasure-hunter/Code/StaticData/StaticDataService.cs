using System;
using System.Collections.Generic;
using System.Linq;
using Code.Audio;
using Code.Audio.Configs;
using Code.Common.Curtains.Configs;
using Code.Common.Extensions;
using Code.Gameplay.Cameras.Configs;
using Code.Gameplay.Character.Configs;
using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Configs;
using Code.Gameplay.VisualEffects;
using Code.Gameplay.VisualEffects.Configs;
using Code.Infrastructure.ResourceManagement;
using Code.Infrastructure.UI.Windows;
using Code.Infrastructure.UI.Windows.Configs;
using Code.Levels.Configs;
using Godot;

namespace Code.StaticData;

public class StaticDataService : IStaticDataService, IDisposable
{
  private readonly IResourcesProvider _resourcesProvider;
  private readonly Dictionary<WindowName, PackedScene> _windows = new();
  private readonly Dictionary<EffectName, EffectConfig> _effects = new();
  private readonly Dictionary<MusicName, MusicConfig> _musics = new();
  private readonly Dictionary<DustParticleEffectName, PackedScene> _particleEffects = new();
  private readonly Dictionary<EnemyName, EnemyConfig> _enemies = new();
  private readonly List<LevelConfig> _levels = new();

  public CameraConfig CameraConfig { get; private set; }
  public CharacterConfig CharacterConfig { get; private set; }
  public AudioConfig AudioConfig { get; private set; }
  public CurtainConfig CurtainConfig { get; private set; }
  public WindowConfig WindowConfig { get; private set; }
  public VisualEffectConfig VisualEffectConfig { get; private set; }

  public int NumberOfLevels => _levels.Count;

  public StaticDataService(IResourcesProvider resourcesProvider)
  {
    _resourcesProvider = resourcesProvider;
  }

  public void Initialize()
  {
    LoadCurtainConfig();
    LoadWindowsConfig();
    LoadLevelConfig();
    LoadAudioConfig();
    LoadCharacterConfig();
    LoadCameraConfig();
    LoadEnemiesConfig();
    LoadVisualEffectConfig();
  }

  public PackedScene GetParticleEffectPrefab(DustParticleEffectName name) => _particleEffects[name];
  public PackedScene GetWindowPrefab(WindowName name) => _windows[name];
  public LevelConfig GetLevelConfig(int level) => _levels[level];
  public MusicConfig GetMusicConfig(MusicName name) => _musics[name];
  public EffectConfig GetEffectConfig(EffectName name) => _effects[name];
  public EnemyConfig GetEnemyConfig(EnemyName name) => _enemies[name];
  
  private void LoadAudioConfig() =>
    AudioConfig = _resourcesProvider.Load<AudioConfig>("res://Configs/Audio/AudioConfig.tres")
      .With(cfg => _effects.AddRange(cfg.Effects.ToDictionary(c => c.Name)))
      .With(cfg => _musics.AddRange(cfg.Musics.ToDictionary(c => c.Name)));

  private void LoadLevelConfig() =>
    _levels.AddRange(_resourcesProvider.LoadAll<LevelConfig>("res://Configs/Levels").OrderBy(c => c.Number));
  
  private void LoadCurtainConfig() => 
    CurtainConfig = _resourcesProvider.Load<CurtainConfig>("res://Configs/Curtain/CurtainConfig.tres");

  private void LoadWindowsConfig() =>
    WindowConfig = _resourcesProvider.Load<WindowConfig>("res://Configs/Windows/WindowsConfig.tres")
      .With(config => _windows.AddRange(config.Prefabs.ToDictionary(c => c.Name, c => c.Prefab)));

  private void LoadCharacterConfig() =>
    CharacterConfig = _resourcesProvider.Load<CharacterConfig>("res://Configs/Characters/CharacterConfig.tres");
  
  private void LoadCameraConfig() =>
    CameraConfig = _resourcesProvider.Load<CameraConfig>("res://Configs/Cameras/CameraConfig.tres");

  private void LoadEnemiesConfig() => 
    _enemies.AddRange(_resourcesProvider.LoadAll<EnemyConfig>("res://Configs/Enemies").ToDictionary(c => c.Name));
  
  private void LoadVisualEffectConfig() =>
    VisualEffectConfig = _resourcesProvider.Load<VisualEffectConfig>("res://Configs/VisualEffects/VisualEffectConfig.tres")
      .With(config => _particleEffects.AddRange(config.DustEffectPrefabs.ToDictionary(c => c.Name, c => c.Prefab)));
  
  void IDisposable.Dispose()
  {
    CharacterConfig = null;
    CurtainConfig = null;
    CameraConfig = null;
    WindowConfig = null;
    AudioConfig = null;
    VisualEffectConfig = null;
    
    _particleEffects.Clear();
    _windows.Clear();
    _effects.Clear();
    _musics.Clear();
    _levels.Clear();
  }
}