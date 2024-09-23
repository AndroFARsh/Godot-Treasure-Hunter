using Godot;

namespace Code.Infrastructure.Windows;

public abstract partial class BaseWindow: Control, IWindow
{
  public Node Node => this;
  
  
  // This method would be called right after window created 
  public virtual void OnCreate()
  {
  }

  // This method would be called right before window would be shown
  public virtual void OnDestroy()
  {
  }
  
  // This method would be called right after window would be hidden
  protected virtual void OnPause()
  {
  }
  
  // This method would be called right before window would be shown
  protected virtual void OnResume()
  {
  }
      
  public override void _Ready() => OnCreate();

  protected override void Dispose(bool disposing)
  {
    OnDestroy();
    base.Dispose(disposing);
  }
  
  void IWindow.Resume()
  {
    OnResume();
    Visible = true;
  }

  void IWindow.Pause()
  {
    Visible = false;
    OnPause();
    
  }
}