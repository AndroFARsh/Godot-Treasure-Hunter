namespace Code.Audio.Services;

public interface IAudioService
{
  void Initialize();
  
  void PlayMusic(MusicName name);
    
  void StopMusic();
    
  void PlayEffect(EffectName name);

  void SetVolume(AudioBus bus, float value);
}