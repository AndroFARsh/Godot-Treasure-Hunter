using System.Collections.Generic;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Projects.States;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUiPresenter : IUiViewPresenter<LevelsMenuUiView>
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
    
    public void OnAttach(LevelsMenuUiView view)
    {
      view.Back.Pressed += OnBackClick;
      for (int level = 0; level < _staticDataService.NumberOfLevels; level++)
      {
        LevelButtonUiView button = _factory.CreateButton(level);
        _buttons.Add(button);
        view.Content.AddChild(button);
      }
    }

    public void OnDetach(LevelsMenuUiView view)
    {
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