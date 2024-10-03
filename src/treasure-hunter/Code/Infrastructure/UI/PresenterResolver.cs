namespace Code.Infrastructure.UI;

public class PresenterResolver : IPresenterResolver
{
  private readonly IUiViewPresenter[] _presenters;

  public PresenterResolver(IUiViewPresenter[] presenters)
  {
    _presenters = presenters;
  }

  public bool TryResolve(IUiView view, out IUiViewPresenter result)
  {
    foreach (IUiViewPresenter presenter in _presenters)
    {
      if (!presenter.IsSupported(view)) continue;
      
      result = presenter;
      return true;
    }

    result = default;
    return false;
  }
}