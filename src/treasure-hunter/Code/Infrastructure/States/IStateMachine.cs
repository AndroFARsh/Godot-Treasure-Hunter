using Code.Infrastructure.LifeTime;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Infrastructure.States
{
  public interface IStateMachine: ITickable
  {
    void Enter<TState>() where TState : class, INoPayloadState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
  }
}