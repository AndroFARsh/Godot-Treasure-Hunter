using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Projects.States;

namespace Code.SettingsWindow
{
  public class SettingsWindowPresenter : IUiViewPresenter<SettingsWindowView>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;

    public SettingsWindowPresenter(IWindowService windowService, IStateMachine stateMachine)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(SettingsWindowView view)
    {
      view.Credits.Pressed += OnCreditsClick;
      view.Save.Pressed += OnSaveClick;
      view.Back.Pressed += OnBackClick;
    }

    public void OnDetach(SettingsWindowView view)
    {
      view.Credits.Pressed -= OnCreditsClick;
      view.Save.Pressed -= OnSaveClick;
      view.Back.Pressed -= OnBackClick;
    }

    private void OnCreditsClick()
    {
      _stateMachine.Enter<LoadCreditsState>();
      _windowService.Pop();
    } 
    
    private void OnBackClick()
    {
      _windowService.Pop();
    }

    private void OnSaveClick()
    {
      _windowService.Pop();
    }
  }
}