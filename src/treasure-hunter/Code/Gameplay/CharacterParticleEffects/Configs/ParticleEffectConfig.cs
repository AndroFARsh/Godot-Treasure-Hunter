using Godot;

namespace Code.Gameplay.CharacterParticleEffects.Configs;

[GlobalClass]
public partial class ParticleEffectConfig : Resource
{
  [Export] public ParticleEffectName Name;
  [Export] public PackedScene Prefab;
}