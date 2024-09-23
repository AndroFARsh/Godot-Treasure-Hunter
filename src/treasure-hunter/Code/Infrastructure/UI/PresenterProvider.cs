namespace Code.Infrastructure.UI;

public class PresenterProvider : IPresenterProvider
{
  private readonly IUiViewPresenter[] _presenters;

  public PresenterProvider(IUiViewPresenter[] presenters)
  {
    _presenters = presenters;
  }

  public bool TryGetPresenter(IUiView view, out IUiViewPresenter result)
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