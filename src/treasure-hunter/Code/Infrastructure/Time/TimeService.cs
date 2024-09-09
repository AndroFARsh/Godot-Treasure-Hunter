using System;
using Code.Infrastructure.LifeTime;

namespace Code.Infrastructure.Time
{
  public class TimeService : ITimeService, ITickable
  {
    private bool _paused;
    private float _deltaTime;

    public float ContinuesDeltaTime => _deltaTime;
    public float DeltaTime => !_paused ? _deltaTime : 0f;

    public DateTime UtcNow => DateTime.UtcNow;

    public void Pause() => _paused = true;
    
    public void Resume() => _paused = false;

    public void Tick(double deltaTime) => _deltaTime = (float)deltaTime;
  }
}