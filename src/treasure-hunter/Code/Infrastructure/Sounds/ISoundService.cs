namespace Code.Infrastructure.Sounds
{
  public interface ISoundService
  {
    void PlayMusic(MusicName name);
    void StopMusic(MusicName name);
    void PlayEffect(FxName name);
    
    void MusicVolumeChanged(float value);
    
    void EffectVolumeChanged(float value);
  }
}