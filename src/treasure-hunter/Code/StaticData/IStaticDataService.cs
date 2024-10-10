using Code.Audio;
using Code.Audio.Configs;
using Code.Common.Curtains.Configs;
using Code.Gameplay.Cameras.Configs;
using Code.Gameplay.Character.Configs;
using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Configs;
using Code.Gameplay.VisualEffects;
using Code.Gameplay.VisualEffects.Configs;
using Code.Infrastructure.UI.Windows;
using Code.Infrastructure.UI.Windows.Configs;
using Code.Levels.Configs;
using Godot;

namespace Code.StaticData;

public interface IStaticDataService
{
  CurtainConfig CurtainConfig { get; }
    
  WindowConfig WindowConfig { get; }

  CameraConfig CameraConfig { get; }

  CharacterConfig CharacterConfig { get; }

  AudioConfig AudioConfig { get; }
  
  VisualEffectConfig VisualEffectConfig { get; }
  
  int NumberOfLevels { get; }
  
  void Initialize();
  
  PackedScene GetParticleEffectPrefab(DustParticleEffectName name);
  PackedScene GetWindowPrefab(WindowName name);
  LevelConfig GetLevelConfig(int level);
  MusicConfig GetMusicConfig(MusicName name);
  EffectConfig GetEffectConfig(EffectName name);
  EnemyConfig GetEnemyConfig(EnemyName name);
}