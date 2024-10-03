using Godot;

namespace Code.Projects.Providers.Curtains;

public class CurtainNodeProvider : ICurtainNodeProvider
{
  public ColorRect Get { get; private set; }
  public void Retain(ColorRect node) => Get = node;

  public void Release() => Get = null;
}