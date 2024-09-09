using Code.Infrastructure.LifeTime;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.Resolvers;

namespace Code.Infrastructure.States
{
  public class StateMachine : IStateMachine, ITickable
  {
    private readonly IStateResolver _resolver;
    
    private IState _activeState;

    public StateMachine(IStateResolver resolver)
    {
      _resolver = resolver;
    }

    public async void Enter<TState>() where TState : class, INoPayloadState
    {
      if (_activeState != null)
        await _activeState.Exit();

      TState newState = ResolveState<TState>();
      _activeState = newState;
      
      newState.Enter();
    }

    public async void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      if (_activeState != null)
        await _activeState.Exit();

      TState newState = ResolveState<TState>();
      _activeState = newState;
      
      newState.Enter(payload);
    }

    public void Tick(double deltaTime)
    {
      if (_activeState is ITickableState updateableState)
        updateableState.Tick();
    }
    
    private TState ResolveState<TState>() where TState : class, IState => _resolver.Resolve<TState>();
  }
}