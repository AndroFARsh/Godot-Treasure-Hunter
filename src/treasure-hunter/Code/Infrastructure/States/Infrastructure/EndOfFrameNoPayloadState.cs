using System.Threading;
using GodotTask;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class EndOfFrameNoPayloadState : INoPayloadState, ITickableState {
    private CancellationTokenSource _cancellationTokenSource;

    protected abstract void OnEnter();

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

      await GDTask.WaitUntilCanceled(_cancellationTokenSource.Token); 
      await OnExitAsync();
      
      _cancellationTokenSource.Dispose();
      _cancellationTokenSource = null;
    }

    void ITickableState.Tick()
    {
      if (_cancellationTokenSource == null)
        OnTick();
      
      if (_cancellationTokenSource != null)
        _cancellationTokenSource.Cancel();
    }

    void INoPayloadState.Enter() => OnEnter();
  }
}