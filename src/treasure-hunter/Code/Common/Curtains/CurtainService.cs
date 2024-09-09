using Code.Common.Curtains.Configs;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.Time;
using Code.Projects;
using Godot;
using GodotTask;

namespace Code.Common.Curtains
{
  public class CurtainService : ICurtainService
  {
    private bool _inProgress;
    private bool _shown;
    
    private readonly IProject _root;
    private readonly IStaticDataService _staticDataService;
    private readonly ITimeService _timeService;
    
    public CurtainService(IProject root, IStaticDataService staticDataService, ITimeService timeService)
    {
      _root = root;
      _staticDataService = staticDataService;
      _timeService = timeService;
    }
    
    public async GDTask ShowCurtain()
    {
      if (_inProgress || _shown) return;
      _inProgress = true;
      _shown = true;
      
      _root.Curtain.Visible = true;
      _root.Curtain.Color = _root.Curtain.Color with { A = 0f };

      CurtainConfig config = _staticDataService.CurtainConfig;
      float time = config.FadeInCurve.MinValue;
      while (time < config.FadeInCurve.MaxValue)
      {
        time = Mathf.Clamp(
          time + _timeService.ContinuesDeltaTime * config.FadeInSpeed, 
          config.FadeInCurve.MinValue, 
          config.FadeInCurve.MaxValue
        );
        _root.Curtain.Color = _root.Curtain.Color with { A =  Mathf.Clamp(config.FadeInCurve.Sample(time), 0, 1f) };

        await GDTask.NextFrame();
      }

      _root.Curtain.Color = _root.Curtain.Color with { A = 1f };
      _inProgress = false;
    }

    public async GDTask HideCurtain()
    {
      if (_inProgress || !_shown) return;
      _inProgress = true;

      _root.Curtain.Visible = true;
      _root.Curtain.Color = _root.Curtain.Color with { A = 1f };

      CurtainConfig config = _staticDataService.CurtainConfig;
      float time = config.FadeOutCurve.MinValue;
      while (time < config.FadeOutCurve.MaxValue)
      {
        time = Mathf.Clamp(
          time + _timeService.ContinuesDeltaTime * config.FadeOutSpeed, 
          config.FadeOutCurve.MinValue, 
          config.FadeOutCurve.MaxValue
        );
        _root.Curtain.Color = _root.Curtain.Color with { A = Mathf.Clamp(config.FadeOutCurve.Sample(time), 0, 1f) };
        
        await GDTask.NextFrame();
      }

      _shown = false;
      _inProgress = false;

      _root.Curtain.Color = _root.Curtain.Color with { A = 0f };
      _root.Curtain.Visible = false;
    }
  }
}