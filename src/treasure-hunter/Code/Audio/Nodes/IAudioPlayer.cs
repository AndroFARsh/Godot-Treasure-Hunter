using Godot;

namespace Code.Audio.Nodes;

public interface IAudioPlayer
{
  bool IsPlaying { get; }
  
  float Volume { get; set; }
  float Pitch { get; set; }
  
  AudioStream Stream { get; set; }
  bool Loop { get; set; }

  void Play();
  
  void Stop();
}