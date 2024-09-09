using Code.Infrastructure.States.Infrastructure;

namespace Code.Infrastructure.States.Resolvers
{
  public interface IStateResolver
  {
    TState Resolve<TState>() where TState : class, IState;
  }
}