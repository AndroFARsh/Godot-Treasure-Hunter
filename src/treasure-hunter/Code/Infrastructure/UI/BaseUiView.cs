using Godot;
using Ninject;

namespace Code.Infrastructure.UI;

public abstract partial class BaseUiView<TUiView> : Control, IUiView
  where TUiView : class, IUiView
{
  private IUiViewPresenter<TUiView> _viewPresenter;

  [Inject]
  public void Construct(IUiViewPresenter<TUiView> viewPresenter)
  {
    _viewPresenter = viewPresenter;
  }
  
  public override void _EnterTree()
  {
    _viewPresenter.OnAttach(this as TUiView);
    OnCreate();
  }

  public override void _ExitTree()
  {
    OnDestroy();
    _viewPresenter.OnDetach(this as TUiView);
  }

  protected virtual void OnCreate()
  {
  }

  protected virtual void OnDestroy()
  {
  }
}