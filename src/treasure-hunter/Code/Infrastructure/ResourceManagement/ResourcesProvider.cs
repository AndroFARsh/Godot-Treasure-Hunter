using System.Collections.Generic;
using System.IO;
using Godot;

namespace Code.Infrastructure.ResourceManagement
{
  public class ResourcesProvider : IResourcesProvider
  {
    public T Load<T>(string path) where T : Resource => ResourceLoader.Load<T>(path);
    
    public Resource Load(string path) => ResourceLoader.Load(path);

    public List<T> LoadAll<T>(string dirPath, bool recursive) where T : Resource
    {
      List<T> result = new();
      LoadAll(dirPath, result, recursive);
      return result;
    }

    public List<Resource> LoadAll(string dirPath, bool recursive)
    {
      List<Resource> result = new();
      LoadAll(dirPath, result, recursive);
      return result;
    }

    public int LoadAll<T>(string dirPath, List<T> result, bool recursive) where T : Resource
    {
      int count = 0;
      DirAccess dir = DirAccess.Open(dirPath);
      if (dir != null) {
        dir.ListDirBegin();
        
        string childName = dir.GetNext();
        while (!string.IsNullOrEmpty(childName))
        {
          string childPath = Path.Join(dirPath, childName);
          if (recursive && dir.CurrentIsDir())
            count += LoadAll(childPath, result, recursive);
          else if (!dir.CurrentIsDir() && ResourceLoader.Load(childPath) is T resource)
          {
            result.Add(resource);
            count++;
          }
          childName = dir.GetNext();
        }
      }

      return count;
    }
  }
}