using Code.Infrastructure.Instantioator;
using Code.StaticData;
using Godot;

namespace Code.Infrastructure.UI.Windows.Factories;

public class WindowFactory : IWindowFactory
{
  private readonly IStaticDataService _staticDataService;
  private readonly IInstantiator _instantiator;

  public WindowFactory(IStaticDataService staticDataService, IInstantiator instantiator)
  {
    _staticDataService = staticDataService;
    _instantiator = instantiator;
  }

  public IWindow CreateWindow(WindowName name)
  {
    PackedScene prefab = _staticDataService.GetWindowPrefab(name);
    BaseWindow window = _instantiator.Instantiate<BaseWindow>(prefab);
    window.Visible = false;
    return window;
  }
}