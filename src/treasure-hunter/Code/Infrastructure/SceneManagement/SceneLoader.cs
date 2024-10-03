using System;
using System.Collections.Generic;
using Code.Infrastructure.Instantioator;
using Code.Projects;
using Code.Projects.Providers.Scenes;
using Godot;
using GodotTask;

namespace Code.Infrastructure.SceneManagement
{
  public class SceneLoader : ISceneLoader, IDisposable
  {
    private readonly ISceneRootProvider _root;
    private readonly Instantiator _instantiator;
    private readonly IDictionary<string, Node> _scenes = new Dictionary<string, Node>();
    
    public SceneLoader(ISceneRootProvider root, Instantiator instantiator)
    {
      _root = root;
      _instantiator = instantiator;
    }

    public IEnumerable<string> LoadedScenes() => _scenes.Keys;

    public async GDTask LoadSceneAsync(string path)
    {
      Node scene = await GDTask.RunOnThreadPool(() => LoadAndInstantiateScene(path));
      _scenes.Add(path, scene);
      _root.Get.AddChild(scene);
    }

    public void LoadScene(string path)
    {
      Node scene = LoadAndInstantiateScene(path);
      _scenes.Add(path, scene);
      _root.Get.AddChild(scene);
    }

    public void UnloadAllScenes()
    {
      foreach (Node child in _scenes.Values)
      {
        _root.Get.RemoveChild(child);
        child.QueueFree();
      }

      _scenes.Clear();
    }

    public void UnloadScene(string path)
    {
      if (_scenes.Remove(path, out Node scene) && scene != null)
      {
        scene.GetParent()?.RemoveChild(scene);
        scene.QueueFree();
      }
    }

    private Node LoadAndInstantiateScene(string path) => _instantiator.Instantiate(path);
    
    public void Dispose()
    {
      foreach (Node scene in _scenes.Values)
      {
        scene.GetParent()?.RemoveChild(scene);
        scene.QueueFree();
      }
      _scenes.Clear();
    }
  }
}