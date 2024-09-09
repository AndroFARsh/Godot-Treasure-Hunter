namespace Code.Infrastructure.LifeTime;

public interface ITickable
{
  void Tick(double deltaTime);
}