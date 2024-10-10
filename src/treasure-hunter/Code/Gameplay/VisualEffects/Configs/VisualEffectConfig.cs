using Godot;

namespace Code.Gameplay.VisualEffects.Configs;

[GlobalClass]
public partial class VisualEffectConfig : Resource
{
  [Export] public DustParticleEffectConfig[] DustEffectPrefabs;
  
  [ExportGroup("Land Squash Effect")] 
  [Export(PropertyHint.Range, "0f, 1")] public float LandSquashScaleFactor = 0.5f;
  [Export] public float LandSquashDuration = 0.1f;
}