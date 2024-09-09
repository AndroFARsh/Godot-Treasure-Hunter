using Code.Infrastructure.Instantioator;
using Entitas;

namespace Code.Infrastructure.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly IInstantiator _instantiator;

    public SystemFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public T Create<T>(params object[] args) where T : ISystem => _instantiator.Instantiate<T>(args);
  }
}