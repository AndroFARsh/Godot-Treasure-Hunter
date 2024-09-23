
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Projects.Settings;
using Code.Projects.States;
using Godot;

namespace Code.Credits.UI.About;

public class AboutUiPresenter : IUiViewPresenter
{
  private readonly IStateMachine _stateMachine;
  private readonly IProjectSettings _projectSettings;

  public AboutUiPresenter(IStateMachine stateMachine, IProjectSettings projectSettings)
  {
    _stateMachine = stateMachine;
    _projectSettings = projectSettings;
  }

  public bool IsSupported(IUiView view) => view is AboutUiView;
  
  public void OnAttach(IUiView v)
  {
    AboutUiView view = v as AboutUiView;
    view.Title.Text = _projectSettings.Name;
    view.Version.Text = _projectSettings.Version;
    view.Back.Pressed += OnBackClick;
    view.Eula.Pressed += OnEulaClick;
    view.PrivacyPolicy.Pressed += OnPrivacyPolicyClick;
  }
  
  public void OnDetach(IUiView v)
  {
    AboutUiView view = v as AboutUiView;
    view.Back.Pressed -= OnBackClick;
    view.Eula.Pressed -= OnEulaClick;
    view.PrivacyPolicy.Pressed -= OnEulaClick;
  }
  
  private void OnBackClick() => _stateMachine.Enter<LoadHomeState>();
    
  private void OnEulaClick() => OS.ShellOpen("https://www.google.com/search?q=eula");
    
  private void OnPrivacyPolicyClick() => OS.ShellOpen("https://www.google.com/search?q=privacy+policy");
}
