using Godot;

namespace Code.Audio.Nodes;

public partial class AudioPlayer : Node, IAudioPlayer
{
  [Export] private AudioStreamPlayer _audioStream;
  
  public bool IsPlaying => _audioStream.IsPlaying();

  public AudioBus Bus
  {
    get => _audioStream.GetBus().ToAudioBus(); 
    set => _audioStream.SetBus(value.AsName());
  }
  
  public float Pitch
  {
    get => _audioStream.PitchScale;
    set => _audioStream.PitchScale = value;
  } 
  
  public AudioStream Stream
  {
    get => _audioStream.GetStream();
    set => _audioStream.SetStream(value);
  }

  public void Play()
  {
    if (!IsPlaying)
      _audioStream.Play();
  }

  public void Stop()
  {
    if (IsPlaying)
      _audioStream.Stop();
  }
}