namespace Code.Infrastructure.UI;

public interface IPresenterProvider
{
  bool TryGetPresenter(IUiView view, out IUiViewPresenter result);
}