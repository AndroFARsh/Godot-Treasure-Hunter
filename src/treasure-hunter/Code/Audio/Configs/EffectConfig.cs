using Godot;

namespace Code.Audio.Configs;

[GlobalClass]
public partial class EffectConfig : Resource
{
  [Export] public EffectName Name;
  [Export(PropertyHint.Range, "-1, 1")] public float Pint;
  [Export] public AudioStream Value;
}