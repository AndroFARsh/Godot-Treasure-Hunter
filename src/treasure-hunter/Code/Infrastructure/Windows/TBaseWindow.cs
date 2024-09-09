using Code.Infrastructure.UI;
using Ninject;

namespace Code.Infrastructure.Windows;

public abstract partial class TBaseWindow<TWindow> : BaseWindow
  where TWindow : class, IWindow
{
  private IUiViewPresenter<TWindow> _viewPresenter;
    
  [Inject]
  public void Construct(IUiViewPresenter<TWindow> viewPresenter) => _viewPresenter = viewPresenter;

  protected override void OnResume() => _viewPresenter.OnAttach(this as TWindow);
  
  protected override void OnPause() => _viewPresenter.OnDetach(this as TWindow);
  
}