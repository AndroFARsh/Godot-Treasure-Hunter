using System.Threading;
using GodotTask;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class EndOfFramePayloadState<TPayload> : IPayloadState<TPayload>, ITickableState {
    private CancellationTokenSource _cancellationTokenSource;
    
    protected abstract void OnEnter(TPayload payload);

    protected virtual void OnTick()
    {
      // no-op
    }
    
    protected virtual void OnExit()
    {
      // no-op
    }

    protected virtual GDTask OnExitAsync()
    {
      OnExit();
      return GDTask.CompletedTask;
    }
    
    async GDTask IState.Exit()
    {
      _cancellationTokenSource = new CancellationTokenSource();

      await GDTask.FromCanceled(_cancellationTokenSource.Token);
      await OnExitAsync();
      
      _cancellationTokenSource.Dispose();
      _cancellationTokenSource = null;
    }

    void ITickableState.Tick()
    {
      if (_cancellationTokenSource == null)
        OnTick();
      
      _cancellationTokenSource?.Cancel();
    }

    void IPayloadState<TPayload>.Enter(TPayload payload) => OnEnter(payload);
  }
}