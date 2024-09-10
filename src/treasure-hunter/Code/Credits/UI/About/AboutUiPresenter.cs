
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Projects.Settings;
using Code.Projects.States;
using Godot;

namespace Code.Credits.UI.About;

public class AboutUiPresenter : IUiViewPresenter<AboutUiView>
{
  private readonly IStateMachine _stateMachine;
  private readonly IProjectSettings _projectSettings;

  public AboutUiPresenter(IStateMachine stateMachine, IProjectSettings projectSettings)
  {
    _stateMachine = stateMachine;
    _projectSettings = projectSettings;
  }
    
  public void OnAttach(AboutUiView view)
  {
    view.Title.Text = _projectSettings.Name;
    view.Version.Text = _projectSettings.Version;
    view.Back.Pressed += OnBackClick;
    view.Eula.Pressed += OnEulaClick;
    view.PrivacyPolicy.Pressed += OnPrivacyPolicyClick;
  }
  
  public void OnDetach(AboutUiView view)
  {
    view.Back.Pressed -= OnBackClick;
    view.Eula.Pressed -= OnEulaClick;
    view.PrivacyPolicy.Pressed -= OnEulaClick;
  }
  
  private void OnBackClick() => _stateMachine.Enter<LoadHomeState>();
    
  private void OnEulaClick() => OS.ShellOpen("https://www.google.com/search?q=eula");
    
  private void OnPrivacyPolicyClick() => OS.ShellOpen("https://www.google.com/search?q=privacy+policy");
}
