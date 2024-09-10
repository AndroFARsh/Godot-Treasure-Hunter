using Godot;

namespace Code.Audio.Nodes;

public interface IAudioPlayer
{
  bool IsPlaying { get; }
  
  float Pitch { get; set; }
  
  AudioStream Stream { get; set; }
  
  AudioBus Bus { get; set; } 

  void Play();
  
  void Stop();
}