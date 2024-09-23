using Code.Infrastructure.UI;
using Godot;
using Ninject;

namespace Code.Infrastructure.Windows;

public abstract partial class BaseWindow: Control, IWindow
{
  public Node Node => this;
  
  private IUiViewPresenter _presenter;

  [Inject]
  public void Construct(IPresenterProvider presenterProvider)
  {
    presenterProvider.TryGetPresenter(this, out _presenter);
  }
  
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
    _presenter.OnAttach(this);
    OnResume();
    Visible = true;
  }

  void IWindow.Pause()
  {
    Visible = false;
    OnPause();
    _presenter.OnDetach(this);
  }
}