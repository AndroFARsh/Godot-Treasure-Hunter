using System;
using Godot;
using Ninject.Parameters;

namespace Code.Infrastructure.Instantioator
{
  public interface IInstantiator
  {
    T Instantiate<T>(string path) where T: Node;
    
    Node Instantiate(string path);
    
    T Instantiate<T>(PackedScene packedScene) where T: Node;

    Node Instantiate(PackedScene packedScene);
    
    T Instantiate<T>(params object[] args);
    
    object Instantiate(Type concreteType, params object[] args);
  }
}