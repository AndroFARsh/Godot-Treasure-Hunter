namespace Code.Infrastructure.UI
{
  public interface IUiViewPresenter<TUiView> where TUiView : IUiView
  {
    void OnAttach(TUiView view);
    
    void OnDetach(TUiView view);
  }
}