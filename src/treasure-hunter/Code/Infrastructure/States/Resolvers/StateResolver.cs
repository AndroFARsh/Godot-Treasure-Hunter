using System;
using System.Collections.Generic;
using Code.Infrastructure.Instantioator;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Infrastructure.States.Resolvers
{
  class StateResolver : IStateResolver
  {
    private readonly IInstantiator _instantiator;
    private readonly Dictionary<Type, IState> _states = new();
    
    public StateResolver(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public TState Resolve<TState>() where TState : class, IState
    {
      Type type = typeof(TState);
      if (!_states.TryGetValue(type, out IState state))
      {
        state = _instantiator.Instantiate<TState>();
        _states.Add(type, state);
      }

      return state as TState;
    }
  }
}