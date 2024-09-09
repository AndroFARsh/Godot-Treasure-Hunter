using Code.Infrastructure.StaticData;
using Code.Infrastructure.Time;
using Code.Infrastructure.Windows.Configs;
using Code.Infrastructure.Windows.Services;
using Godot;
using GodotTask;
using Ninject;

namespace Code.Infrastructure.UI
{
  public partial class WindowRoot : Control, IWindowRoot
  {
    [Export] public ColorRect Background { get; private set; }
    [Export] public Control Content { get; private set; }
    
    private IStaticDataService _staticDataService;
    private IWindowService _windowService;
    private ITimeService _timeService;
    private bool _inProgress;
    private bool _shown;
    
    [Inject]
    public void Construct(IWindowService windowService, ITimeService timeService, IStaticDataService staticDataService)
    {
      _timeService = timeService;
      _windowService = windowService;
      _staticDataService = staticDataService;
      
      _windowService.Retain(this);
    }

    protected override void Dispose(bool disposing) 
    {
      _windowService.Release();
      base.Dispose(disposing);
    }
    
    public async GDTask ShowBackground()
    {
      if (_inProgress || _shown) return;
      _inProgress = true;
      _shown = true;
      
      Visible = true;
      WindowServiceConfig config = _staticDataService.WindowServiceConfig;
      
      Background.Color = Background.Color with { A = 0f };
      
      float time = _staticDataService.CurtainConfig.FadeInCurve.MinValue;
      while (time < _staticDataService.CurtainConfig.FadeInCurve.MaxValue)
      {
        time = Mathf.Clamp(time + _timeService.ContinuesDeltaTime * config.FadeInSpeed, config.FadeInCurve.MinValue, config.FadeInCurve.MaxValue);
        Background.Color = Background.Color with { A = Mathf.Clamp(config.FadeInCurve.Sample(time), 0, config.MaxAlpha) };

        await GDTask.NextFrame();
      }
      
      Background.Color = Background.Color with { A = config.MaxAlpha };
      _inProgress = false;
    }

    public async GDTask HideBackground()
    {
      if (_inProgress || !_shown) return;
      _inProgress = true;

      Visible = true;
      WindowServiceConfig config = _staticDataService.WindowServiceConfig;
      
      Background.Color = Background.Color with { A = config.MaxAlpha };

      float time = config.FadeOutCurve.MinValue;
      while (time < config.FadeOutCurve.MaxValue)
      {
        time = Mathf.Clamp(time + _timeService.ContinuesDeltaTime * config.FadeOutSpeed, config.FadeOutCurve.MinValue, config.FadeOutCurve.MaxValue);
        Background.Color = Background.Color with { A = Mathf.Clamp(config.FadeOutCurve.Sample(time), 0, config.MaxAlpha) };
        
        await GDTask.NextFrame();
      }

      _shown = false;
      _inProgress = false;

      Background.Color = Background.Color with { A = 0f };
      Visible = false;
    }
  }
}