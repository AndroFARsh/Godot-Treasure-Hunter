using Code.Infrastructure.Instantioator;
using Code.Levels.UI.LevelsButton;

namespace Code.Levels.UI.Factories
{
  public class LevelButtonFactory : ILevelButtonFactory
  {
    private const string LevelButtonPrefabPath = "res://Resources/Prefabs/LevelButton.tscn";
    
    private readonly IInstantiator _instantiator;
    
    public LevelButtonFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public LevelButtonUiView CreateButton(int level)
    {
      LevelButtonUiView instantiate = _instantiator.Instantiate<LevelButtonUiView>(LevelButtonPrefabPath);
      instantiate.Level = level;
      return instantiate;
    } 
      
  }
}