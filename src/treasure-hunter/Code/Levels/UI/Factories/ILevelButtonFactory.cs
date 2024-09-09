using Code.Levels.UI.LevelsButton;

namespace Code.Levels.UI.Factories
{
  public interface ILevelButtonFactory
  {
    LevelButtonUiView CreateButton(int level);
  }
}