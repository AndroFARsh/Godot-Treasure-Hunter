using System;
using System.Collections.Generic;
using Code.Audio.Nodes;
using Code.Common.Extensions;
using Code.Infrastructure.Instantioator;
using Code.Projects.Providers.Root;
using Code.StaticData;
using Godot;

namespace Code.Audio.Factories;

public class AudioPlayerFactory : IAudioPlayerFactory, IDisposable
{
  private readonly IRootProvider _root;
  private readonly IInstantiator _instantiator;
  private readonly IStaticDataService _staticDataService;
  private readonly Stack<IAudioPlayer> _audioPlayers = new();

  public AudioPlayerFactory(IInstantiator instantiator, IStaticDataService staticDataService, IRootProvider root)
  {
    _instantiator = instantiator;
    _staticDataService = staticDataService;
    _root = root;
  }

  public IAudioPlayer PeekOrCreate()
  {
    if (!_audioPlayers.TryPop(out IAudioPlayer source))
    {
      PackedScene prefab = _staticDataService.AudioConfig.SourcePrefab;
      source = _instantiator.Instantiate<AudioPlayer>(prefab)
        .With(n => _root.Get.AddChild(n));
    }

    source.Stop();
    return source;
  }

  public void Release(IAudioPlayer source)
  {
    source.Stop();
    _audioPlayers.Push(source);
  }

  void IDisposable.Dispose()
  {
    foreach (IAudioPlayer player in _audioPlayers) player.Destroy();
    
    _audioPlayers.Clear();
  }
}