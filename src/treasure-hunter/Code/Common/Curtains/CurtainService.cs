using Code.Common.Curtains.Configs;
using Code.Infrastructure.Time;
using Code.Projects;
using Code.Projects.Providers.Curtains;
using Code.StaticData;
using Godot;
using GodotTask;

namespace Code.Common.Curtains
{
  public class CurtainService : ICurtainService
  {
    private bool _inProgress;
    private bool _shown;
    
    private readonly ICurtainNodeProvider _nodeProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly ITimeService _timeService;
    
    public CurtainService(ICurtainNodeProvider nodeProvider, IStaticDataService staticDataService, ITimeService timeService)
    {
      _nodeProvider = nodeProvider;
      _staticDataService = staticDataService;
      _timeService = timeService;
    }
    
    public async GDTask ShowCurtain()
    {
      ColorRect curtain = _nodeProvider.Get;
      if (_inProgress || _shown || curtain == null) return;
      _inProgress = true;
      _shown = true;

      curtain.Visible = true;
      curtain.Color = curtain.Color with { A = 0f };

      CurtainConfig config = _staticDataService.CurtainConfig;
      float time = config.FadeInCurve.MinValue;
      while (time < config.FadeInCurve.MaxValue)
      {
        time = Mathf.Clamp(
          time + _timeService.ContinuesDeltaTime * config.FadeInSpeed, 
          config.FadeInCurve.MinValue, 
          config.FadeInCurve.MaxValue
        );
        curtain.Color = curtain.Color with { A =  Mathf.Clamp(config.FadeInCurve.Sample(time), 0, 1f) };

        await GDTask.NextFrame();
      }

      curtain.Color = curtain.Color with { A = 1f };
      _inProgress = false;
    }

    public async GDTask HideCurtain()
    {
      ColorRect curtain = _nodeProvider.Get;
      if (_inProgress || !_shown || curtain == null) return;
      _inProgress = true;

      curtain.Visible = true;
      curtain.Color = curtain.Color with { A = 1f };

      CurtainConfig config = _staticDataService.CurtainConfig;
      float time = config.FadeOutCurve.MinValue;
      while (time < config.FadeOutCurve.MaxValue)
      {
        time = Mathf.Clamp(
          time + _timeService.ContinuesDeltaTime * config.FadeOutSpeed, 
          config.FadeOutCurve.MinValue, 
          config.FadeOutCurve.MaxValue
        );
        curtain.Color = curtain.Color with { A = Mathf.Clamp(config.FadeOutCurve.Sample(time), 0, 1f) };
        
        await GDTask.NextFrame();
      }

      _shown = false;
      _inProgress = false;

      curtain.Color = curtain.Color with { A = 0f };
      curtain.Visible = false;
    }
  }
}