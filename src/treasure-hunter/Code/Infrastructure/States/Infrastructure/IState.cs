using GodotTask;

namespace Code.Infrastructure.States.Infrastructure
{
  public interface IState
  {
    GDTask Exit();
  }
}