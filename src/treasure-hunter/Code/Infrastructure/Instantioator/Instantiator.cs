using System;
using System.Linq;
using Code.Common.Extensions;
using Code.Infrastructure.ResourceManagement;
using Godot;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;



namespace Code.Infrastructure.Instantioator;

public class Instantiator : IInstantiator
{
  private readonly IResolutionRoot _resolutionRoot;
  private readonly IResourcesProvider _resourcesProvider;
    
  public Instantiator(IResolutionRoot resolutionRoot, IResourcesProvider resourcesProvider)
  {
    _resolutionRoot = resolutionRoot;
    _resourcesProvider = resourcesProvider;
  }

  public T Instantiate<T>(string path) where T: Node => 
    Instantiate<T>(_resourcesProvider.Load<PackedScene>(path));

  public Node Instantiate(string path) =>
    Instantiate(_resourcesProvider.Load<PackedScene>(path));

  public T Instantiate<T>(PackedScene packedScene) where T : Node
  {
    Node instance = Instantiate(packedScene);
    T castInstance = (T)instance;
    return castInstance;
  }
    
  public Node Instantiate(PackedScene packedScene) => _resolutionRoot.ResolveDependencies(packedScene.Instantiate());
  
  public T Instantiate<T>(params object[] args) => (T)Instantiate(typeof(T), args);
    
  public object Instantiate(Type concreteType, params object[] args)
  {
    object instance = _resolutionRoot.Get(concreteType, PrepareParameters(args));
      
    return instance;
  }
    
  private static IParameter[] PrepareParameters(object[] args) =>
    args.Select(arg => new TypeMatchingConstructorArgument(arg.GetType(), (_, _) => arg) as IParameter).ToArray();
}