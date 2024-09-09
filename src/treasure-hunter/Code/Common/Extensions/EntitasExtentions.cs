using Entitas;

namespace Code.Common.Extensions
{
  public static class EntitasExtentions
  {
    public static bool IsNullOrEmpty(this IGroup group) => group == null || group.count == 0;
    
    public static bool IsEmpty(this IGroup group) => group.count == 0;
    
    public static bool IsNotEmpty(this IGroup group) => !IsNullOrEmpty(group);
  }
}