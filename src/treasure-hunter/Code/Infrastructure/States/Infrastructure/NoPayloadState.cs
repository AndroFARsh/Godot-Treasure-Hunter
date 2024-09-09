using GodotTask;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class NoPayloadState : INoPayloadState
  {
    protected abstract void OnEnter();

    protected virtual void OnExit()
    {
      // no-op
    }
    
    protected virtual GDTask OnExitAsync()
    {
      OnExit();
      return GDTask.CompletedTask;
    }

    GDTask IState.Exit() => OnExitAsync();

    void INoPayloadState.Enter() => OnEnter();
  }
}