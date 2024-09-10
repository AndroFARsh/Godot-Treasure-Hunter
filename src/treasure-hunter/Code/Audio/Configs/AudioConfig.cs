using Godot;

namespace Code.Audio.Configs;

[GlobalClass]
public partial class AudioConfig : Resource
{
  [Export] public EffectConfig[] Effects;
  [Export] public MusicConfig[] Musics;
     
  [Export] public PackedScene SourcePrefab;
}