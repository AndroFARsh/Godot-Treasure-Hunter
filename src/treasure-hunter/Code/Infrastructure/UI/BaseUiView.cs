using Godot;
using Ninject;

namespace Code.Infrastructure.UI;

public abstract partial class BaseUiView : Control, IUiView
{
  private IUiViewPresenter _presenter;

  [Inject]
  public void Construct(IPresenterProvider presenterProvider)
  {
    presenterProvider.TryGetPresenter(this, out _presenter);
  }
  
  public override void _EnterTree()
  {
    _presenter?.OnAttach(this);
    OnCreate();
  }

  public override void _ExitTree()
  {
    OnDestroy();
    _presenter?.OnDetach(this);
  }

  protected virtual void OnCreate()
  {
  }

  protected virtual void OnDestroy()
  {
  }
}