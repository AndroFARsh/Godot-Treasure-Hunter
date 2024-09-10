using System.Collections.Generic;
using Code.Audio.Nodes;
using Code.Common.Extensions;
using Code.Infrastructure.Instantioator;
using Code.Infrastructure.StaticData;
using Code.Projects;
using Godot;

namespace Code.Audio.Factories;

public class AudioPlayerFactory : IAudioPlayerFactory
{
  private readonly IProject _project;
  private readonly IInstantiator _instantiator;
  private readonly IStaticDataService _staticDataService;
  private readonly LinkedList<IAudioPlayer> _audioPlayers = new();

  public AudioPlayerFactory(IInstantiator instantiator, IStaticDataService staticDataService, IProject project)
  {
    _instantiator = instantiator;
    _staticDataService = staticDataService;
    _project = project;
  }

  public IAudioPlayer PeekOrCreate()
  {
    IAudioPlayer source;
    if (_audioPlayers.Count > 0)
    {
      source = _audioPlayers.First.Value;
      _audioPlayers.RemoveFirst();
    }
    else
    {
      PackedScene prefab = _staticDataService.AudioConfig.SourcePrefab;
      source = _instantiator.Instantiate<AudioPlayer>(prefab)
        .With(n => _project.SceneRoot.AddChild(n));
    }

    return source;
  }

  public void Release(IAudioPlayer source)
  {
    source.Stop();
    _audioPlayers.AddLast(source);
  }
}