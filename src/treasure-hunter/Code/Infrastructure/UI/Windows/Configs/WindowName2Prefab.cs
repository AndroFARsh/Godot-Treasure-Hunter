using Godot;

namespace Code.Infrastructure.UI.Windows.Configs;

[GlobalClass]
public partial class WindowName2Prefab : Resource
{
  [Export] public WindowName Name;
  [Export] public PackedScene Prefab;
}