using Code.Infrastructure.Instantioator;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.Windows.Configs;

namespace Code.Infrastructure.Windows.Factories;

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
    WindowConfig config = _staticDataService.GetWindowConfig(name);
    BaseWindow window = _instantiator.Instantiate<BaseWindow>(config.Prefab);
    window.Visible = false;
    return window;
  }
}