namespace Code.Audio.Services;

public interface IAudioService
{
  void PlayMusic(MusicName name);
    
  void StopMusic();
    
  void PlayEffect(EffectName name);
}