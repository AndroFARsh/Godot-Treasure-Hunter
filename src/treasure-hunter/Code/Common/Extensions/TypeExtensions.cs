using System;
using System.Collections.Generic;

namespace Code.Common.Extensions
{
  public static class TypeExtensions
  {
    private static readonly Dictionary<Type, Type[]> _interfaces = new();

    public static Type[] Interfaces(this Type type)
    {
      if (!_interfaces.TryGetValue(type, out Type[] result))
      {
        result = type.GetInterfaces();
        _interfaces.Add(type, result);
      }

      return result;
    }
  }
}