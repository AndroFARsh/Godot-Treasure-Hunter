using System.Collections.Generic;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Factories;
using Godot;
using GodotTask;

namespace Code.Infrastructure.Windows.Services;

public class WindowService : IWindowService
{
  private readonly IWindowFactory _windowFactory;
    
  private readonly Stack<WindowName> _stack = new();
  private readonly Dictionary<WindowName, IWindow> _windows = new();

  private IWindowRoot _windowRoot;
    
  public WindowService(IWindowFactory windowFactory)
  {
    _windowFactory = windowFactory;
  }

  public void Retain(IWindowRoot windowRoot)
  {
    _windowRoot = windowRoot;
    _windows.Clear();
  }

  public void Push(WindowName name, int flag = 0)
  {
    if (_stack.TryPeek(out WindowName prevName))
    {
      IWindow prevWindow = GetOrCreateWindow(prevName);
      prevWindow.Pause();
      _windowRoot.Content.RemoveChild(prevWindow.Node);
    }

    if ((flag & IWindowService.REPLACE_TOP_FLAG) > 0) _stack.TryPop(out WindowName _);
    if ((flag & IWindowService.CLEAR_STACK_FLAG) > 0) _stack.Clear();

    IWindow window = GetOrCreateWindow(name);
    _windowRoot.Content.AddChild(window.Node);
    
    window.Resume();
      
    _stack.Push(name);
      
    if (_stack.Count >= 0) _windowRoot.ShowBackground().Forget();
  }

  public void Pop()
  {
    if (_stack.TryPop(out WindowName name))
    {
      IWindow window = GetOrCreateWindow(name);
      window.Pause();
      _windowRoot.Content.RemoveChild(window.Node);
    }
      
    if (_stack.TryPeek(out WindowName prevName))
    {
      IWindow prevWindow = GetOrCreateWindow(prevName);
      _windowRoot.Content.AddChild(prevWindow.Node);
      prevWindow.Resume();
    }

    if (_stack.Count == 0) _windowRoot.HideBackground().Forget();
  }
    
  public void Release()
  {
    foreach (IWindow window in _windows.Values)
      window.Node.QueueFree();
    
    _windows.Clear();
    _windowRoot = null;
  }

  private IWindow GetOrCreateWindow(WindowName name)
  {
    if (_windows.TryGetValue(name, out IWindow window))
      return window;

    window = _windowFactory.CreateWindow(name);
    
    _windows.Add(name, window);
    return window;
  }
}