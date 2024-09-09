using System;
using System.Collections.Generic;
using Ninject.Syntax;

namespace Code.Common.Extensions;

public static class BindingRootExtensions
{
  public static IBindingWhenInNamedWithOrOnSyntax<object> BindInterfacesTo<T>(this IBindingRoot binder) 
    => binder.BindInterfacesTo(typeof(T));

  public static IBindingWhenInNamedWithOrOnSyntax<object> BindInterfacesTo(this IBindingRoot binder, Type type)
  {
    Type[] interfaces = type.Interfaces();
    return binder.Bind(interfaces).To(type);
  }
    
  public static IBindingWhenInNamedWithOrOnSyntax<object> BindInterfacesAndSelfTo<T>(this IBindingRoot binder) 
    => binder.BindInterfacesAndSelfTo(typeof(T));

  public static IBindingWhenInNamedWithOrOnSyntax<object> BindInterfacesAndSelfTo(this IBindingRoot binder, Type type)
  {
    List<Type> types = new() { type };
    types.AddRange(type.Interfaces());
      
    return binder.Bind(types.ToArray()).To(type);
  }




}