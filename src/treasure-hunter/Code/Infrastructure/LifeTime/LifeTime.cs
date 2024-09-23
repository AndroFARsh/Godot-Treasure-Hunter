namespace Code.Infrastructure.LifeTime;

public class LifeTime : ILifeTime
{
  private ITickable[] _tickables;
  private IStartable[] _startables;
  private IStopable[] _stopables;

  private bool started;
  
  public LifeTime(IStartable[] startables, ITickable[] tickables, IStopable[] stopables)
  {
    _tickables = tickables;
    _startables = startables;
    _stopables = stopables;
  }
  
  public void Start()
  {
    if (started) return;

    started = true;
    foreach (IStartable startable in _startables)
      startable?.Start();
  }
  
  public void Tick(double deltaTime)
  {
    if (!started) return;

    foreach (ITickable tickable in _tickables)
      tickable?.Tick(deltaTime);
  }

  public void Stop()
  {
    if (!started) return;
    started = false;
    foreach (IStopable stopable in _stopables)
      stopable?.Stop();
    
    _tickables = null;
    _startables = null;
    _stopables = null;
  }
}