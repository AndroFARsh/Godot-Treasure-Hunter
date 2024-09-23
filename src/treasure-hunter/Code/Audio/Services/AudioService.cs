using System;
using Code.Audio.Configs;
using Code.Audio.Factories;
using Code.Audio.Nodes;
using Code.Infrastructure.StaticData;
using Code.Projects.Settings;
using Godot;
using GodotTask;

namespace Code.Audio.Services;

public class AudioService : IAudioService, IDisposable
{
  private readonly IAudioPlayerFactory _audioFactory;
  private readonly IStaticDataService _staticDataService;
  private readonly IProjectSettings _projectSettings;

  private MusicName _music = MusicName.Unknown; 
  private IAudioPlayer _player;
  
  public AudioService(
    IAudioPlayerFactory audioFactory, 
    IStaticDataService staticDataService,
    IProjectSettings projectSettings)
  {
    _audioFactory = audioFactory;
    _staticDataService = staticDataService;
    _projectSettings = projectSettings;
  }

  public void Initialize()
  {
    SetVolume(AudioBus.General, _projectSettings.GeneralVolume);
    SetVolume(AudioBus.Effect, _projectSettings.EffectVolume);
    SetVolume(AudioBus.Music, _projectSettings.MusicVolume);
  }

  public void SetVolume(AudioBus bus, float linearVolume) =>
    AudioServer.SetBusVolumeDb(bus.AsIndex(), Mathf.LinearToDb(linearVolume));

  public void PlayMusic(MusicName music)
  {
    if (_music == music) return;

    MusicConfig config = _staticDataService.GetMusicConfig(music);
    
    _music = music;
    _player ??= _audioFactory.PeekOrCreate();

    _player.Bus = AudioBus.Music;
    _player.Stream = config.Value;
    _player.Play();
  }
    
  public void StopMusic()
  {
    if (_music == MusicName.Unknown) return;

    _music = MusicName.Unknown;
    _player.Stop();
    _audioFactory.Release(_player);
    _player = null;
  }
  
  public async void PlayEffect(EffectName name)
  {
    EffectConfig config = _staticDataService.GetEffectConfig(name);
    IAudioPlayer player = _audioFactory.PeekOrCreate();
    
    player.Bus = AudioBus.Effect;
    player.Stream = config.Value;
    player.Play();
      
    await GDTask.WaitUntil(() => !player.IsPlaying);
    _audioFactory.Release(player);
  }

  public void Dispose()
  {
    _player?.Destroy();
    _player = null;
  }
}