namespace Code.Infrastructure.UI;

public interface IPresenterResolver
{
  bool TryResolve(IUiView view, out IUiViewPresenter result);
}