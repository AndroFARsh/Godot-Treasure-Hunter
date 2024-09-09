namespace Code.Infrastructure.LifeTime;

public interface ILifeTime
{
  void Start();
  void Tick(double deltaTime);
  void Stop();
}