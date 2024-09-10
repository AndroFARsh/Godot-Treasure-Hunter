using Godot;

namespace Code.Audio.Configs;

[GlobalClass]
public partial class MusicConfig : Resource
{
  [Export] public MusicName Name;
  [Export] public AudioStream Value;
}