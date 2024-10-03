using Code.Audio;
using Code.Audio.Configs;
using Code.Common.Curtains.Configs;
using Code.Gameplay.Cameras.Configs;
using Code.Gameplay.Character.Configs;
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
  
  int NumberOfLevels { get; }
  
  void Initialize();
  PackedScene GetWindowPrefab(WindowName name);
  LevelConfig GetLevelConfig(int level);
  MusicConfig GetMusicConfig(MusicName name);
  EffectConfig GetEffectConfig(EffectName name);
}