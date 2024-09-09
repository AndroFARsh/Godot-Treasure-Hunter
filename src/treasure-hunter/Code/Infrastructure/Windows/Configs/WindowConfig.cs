using Godot;

namespace Code.Infrastructure.Windows.Configs;

[GlobalClass]
public partial class WindowConfig : Resource
{
  [Export] public WindowName Name;
  [Export(PropertyHint.NodePathValidTypes, "BaseWindow")] public PackedScene Prefab;
}