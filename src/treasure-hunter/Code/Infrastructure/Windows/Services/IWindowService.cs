using Code.Infrastructure.UI;

namespace Code.Infrastructure.Windows.Services;

public interface IWindowService
{
  public const int REPLACE_TOP_FLAG = 1;
  public const int CLEAR_STACK_FLAG = 2;

  void Retain(IWindowRoot windowRoot);
    
  void Push(WindowName window, int flag = 0);
  void Pop();
    
  void Release();
}