using Code.Audio.Nodes;

namespace Code.Audio.Factories;

public interface IAudioPlayerFactory
{
  IAudioPlayer PeekOrCreate();
  void Release(IAudioPlayer source);
}