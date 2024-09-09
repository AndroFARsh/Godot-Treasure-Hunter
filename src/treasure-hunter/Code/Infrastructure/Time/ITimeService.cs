using System;

namespace Code.Infrastructure.Time
{
  public interface ITimeService
  {
    float ContinuesDeltaTime { get; }
    float DeltaTime { get; }
    DateTime UtcNow { get; }
    void Pause();
    void Resume();
  }
}