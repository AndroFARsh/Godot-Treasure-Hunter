using System.Collections.Generic;
using GodotTask;

namespace Code.Infrastructure.SceneManagement
{
  public interface ISceneLoader
  {
    IEnumerable<string> LoadedScenes();
    
    GDTask LoadSceneAsync(string name);
    
    void LoadScene(string path);
    
    void UnloadScene(string path);
    
    void UnloadAllScenes();
  }
}