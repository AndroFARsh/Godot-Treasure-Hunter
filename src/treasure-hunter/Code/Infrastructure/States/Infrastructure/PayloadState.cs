using GodotTask;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class PayloadState<TPayload> : IPayloadState<TPayload>
  {
    protected abstract void OnEnter(TPayload payload);

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

    void IPayloadState<TPayload>.Enter(TPayload payload) => OnEnter(payload);
  }
}