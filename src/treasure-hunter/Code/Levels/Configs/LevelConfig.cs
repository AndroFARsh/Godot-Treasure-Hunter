
using Godot;

namespace Code.Levels.Configs;

[GlobalClass]
public partial class LevelConfig : Resource
{
  [Export(PropertyHint.Range, "1, 32000")] public int Number;
  [Export] public string Name;
}