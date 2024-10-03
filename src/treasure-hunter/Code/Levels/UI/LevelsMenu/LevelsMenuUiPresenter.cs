using System.Collections.Generic;
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Projects.States;
using Code.StaticData;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUiPresenter : IUiViewPresenter
  {
    private readonly IStaticDataService _staticDataService;
    private readonly ILevelButtonFactory _factory;
    private readonly IStateMachine _stateMachine;
    
    private readonly List<LevelButtonUiView> _buttons = new ();
    
    public LevelsMenuUiPresenter(
      IStaticDataService staticDataService, 
      ILevelButtonFactory factory, 
      IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _factory = factory;
      _stateMachine = stateMachine;
    }

    public bool IsSupported(IUiView view) => view is LevelsMenuUiView;

    public void OnAttach(IUiView v)
    {
      if (v is not LevelsMenuUiView view) return;
      
      view.Back.Pressed += OnBackClick;
      for (int level = 0; level < _staticDataService.NumberOfLevels; level++)
      {
        LevelButtonUiView button = _factory.CreateButton(level);
        _buttons.Add(button);
        view.Content.AddChild(button);
      }
    }

    public void OnDetach(IUiView v)
    {
      if (v is not LevelsMenuUiView view) return;
      
      foreach (LevelButtonUiView button in _buttons)
      {
        view.Content.RemoveChild(button);
        button.QueueFree();
      }

      _buttons.Clear();
    } 
    
    private void OnBackClick() => _stateMachine.Enter<LoadHomeState>();
  }
}