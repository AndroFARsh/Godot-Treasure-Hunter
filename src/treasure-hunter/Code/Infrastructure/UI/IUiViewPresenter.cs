namespace Code.Infrastructure.UI
{
  public interface IUiViewPresenter
  {
    bool IsSupported(IUiView view);
    
    void OnAttach(IUiView view);
    
    void OnDetach(IUiView view);
  }
}