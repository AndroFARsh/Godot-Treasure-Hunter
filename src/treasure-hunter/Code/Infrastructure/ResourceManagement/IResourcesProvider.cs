using System.Collections.Generic;
using Godot;

namespace Code.Infrastructure.ResourceManagement
{
  public interface IResourcesProvider
  {
    Resource Load(string path);
    
    T Load<T>(string path) where T : Resource;
    
    List<T> LoadAll<T>(string dirPath, bool recursive = false) where T : Resource;
    
    List<Resource> LoadAll(string dirPath, bool recursive = false);
    
    int LoadAll<T>(string dirPath, List<T> result, bool recursive = false) where T : Resource;
  }
}