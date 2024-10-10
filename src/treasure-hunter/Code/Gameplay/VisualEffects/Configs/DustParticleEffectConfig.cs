using Godot;

namespace Code.Gameplay.VisualEffects.Configs;

[GlobalClass]
public partial class DustParticleEffectConfig : Resource
{
  [Export] public DustParticleEffectName Name;
  [Export] public PackedScene Prefab;
}