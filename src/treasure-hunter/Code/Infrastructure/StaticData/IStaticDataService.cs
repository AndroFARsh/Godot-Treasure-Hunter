using Code.Audio;
using Code.Audio.Configs;
using Code.Common.Curtains.Configs;
using Code.Gameplay.Character.Configs;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData;

public interface IStaticDataService
{
  CurtainConfig CurtainConfig { get; }
    
  WindowServiceConfig WindowServiceConfig { get; }

  CharacterConfig CharacterConfig { get;  }

  AudioConfig AudioConfig { get; }
  
  int NumberOfLevels { get; }
  
  void Initialize();

  WindowConfig GetWindowConfig(WindowName name);

  LevelConfig GetLevelConfig(int level);
  MusicConfig GetMusicConfig(MusicName name);
  EffectConfig GetEffectConfig(EffectName name);
}