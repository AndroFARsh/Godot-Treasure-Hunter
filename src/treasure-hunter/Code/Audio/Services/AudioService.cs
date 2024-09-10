using Code.Audio.Configs;
using Code.Audio.Factories;
using Code.Audio.Nodes;
using Code.Infrastructure.StaticData;
using Code.PersistentData;
using Code.Projects.Settings;
using GodotTask;

namespace Code.Audio.Services;

public class AudioService : IAudioService
{
  private readonly IAudioPlayerFactory _audioFactory;
  private readonly IStaticDataService _staticDataService;
  private readonly IProjectSettings _settings;

  private MusicName _music = MusicName.Unknown; 
  private IAudioPlayer _player;
  
  public AudioService(
    IAudioPlayerFactory audioFactory, 
    IStaticDataService staticDataService,
    IProjectSettings settings)
  {
    _audioFactory = audioFactory;
    _staticDataService = staticDataService;
    _settings = settings;
  }

  public void PlayMusic(MusicName music)
  {
    if (_music == music) return;

    MusicConfig config = _staticDataService.GetMusicConfig(music);
    
    _music = music;
    _player ??= _audioFactory.PeekOrCreate();
    
    _player.Stream = config.Value;
    _player.Loop = true;
    _player.Volume = _settings.MusicVolume;
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
    player.Stream = config.Value;
    player.Loop = false;
    player.Volume = _settings.EffectVolume;
    player.Play();
      
    await GDTask.WaitUntil(() => !player.IsPlaying);
    _audioFactory.Release(player);
  }

  public void MusicVolumeChanged(float value)
  {
    // foreach (IAudioPlayer player in _playedMusicSource.Values)
    //   player.Volume = value;
  }

  public void EffectVolumeChanged(float value)
  {
  }
}