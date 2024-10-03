using Godot;

namespace Code.Projects.Providers.Curtains;

public interface ICurtainNodeProvider
{
  ColorRect Get { get; }
}