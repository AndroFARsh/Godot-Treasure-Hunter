using GodotTask;

namespace Code.Common.Curtains
{
  public interface ICurtainService
  {
    GDTask ShowCurtain();

    GDTask HideCurtain();
  }
}