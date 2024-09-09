using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entitas.CodeGeneration.Plugins;
using Jenny;

namespace KSyndicate.CustomGenerators.Plugins
{
  public class IEntityExtensionGenerator : AbstractGenerator
  {
    public override string Name => "Static class with bunch helper function for IEntity";

    private const string MatcherTemplate =
      "${ContextName}Entity => System.Array.IndexOf(${ContextName}ComponentsLookup.componentTypes, componentType),";
    
    private const string IEntityExtensionTemplate = @"

public static class IEntityExtensions
{
  public static int LookUpComponentIndex<TComponent>(this Entitas.IEntity entity)
    where TComponent : class, Entitas.IComponent =>
    LookUpComponentIndex(entity, typeof(TComponent));

  public static int LookUpComponentIndex(this Entitas.IEntity entity, System.Type componentType)
  {
    return entity switch
    {
      ${Matchers}
      _ => -1
    };
  }

  public static bool IsComponentAllowed<TComponent>(this Entitas.IEntity entity)
    where TComponent : class, Entitas.IComponent =>
    IsComponentAllowed(entity, typeof(TComponent));

  public static bool IsComponentAllowed(this Entitas.IEntity entity, System.Type componentType) =>
    LookUpComponentIndex(entity, componentType) >= 0;

  public static bool HasComponent<TComponent>(this Entitas.IEntity entity)
    where TComponent : class, Entitas.IComponent =>
    HasComponent(entity, typeof(TComponent));

  public static bool HasComponent(this Entitas.IEntity entity, System.Type componentType)
  {
    int componentIndex = LookUpComponentIndex(entity, componentType);
    return entity.HasComponent(componentIndex);
  }

  public static void AddComponent(this Entitas.IEntity entity, Entitas.IComponent component)
  {
    int componentIndex = LookUpComponentIndex(entity, component.GetType());
    if (componentIndex >= 0)
      entity.AddComponent(componentIndex, component);
    else
      throw new System.Exception($""{nameof(entity.GetType)} do not support component: {nameof(component.GetType)}"");
  }

  public static bool TryAddComponent(this Entitas.IEntity entity, Entitas.IComponent component)
  {
    int componentIndex = LookUpComponentIndex(entity, component.GetType());
    if (componentIndex >= 0 && entity.HasComponent(componentIndex))
    {
      entity.AddComponent(componentIndex, component);
      return true;
    }

    return false;
  }

  public static TComponent GetComponent<TComponent>(this Entitas.IEntity entity)
    where TComponent : class, Entitas.IComponent =>
    (TComponent)GetComponent(entity, typeof(TComponent));

  public static Entitas.IComponent GetComponent(this Entitas.IEntity entity, System.Type componentType)
  {
    int componentIndex = LookUpComponentIndex(entity, componentType);
    return componentIndex >= 0
      ? entity.GetComponent(componentIndex)
      : throw new System.Exception($""{nameof(entity.GetType)} do not support component: {nameof(componentType)}"");
  }

  public static bool TryGetComponent<TComponent>(this Entitas.IEntity entity, out TComponent component)
    where TComponent : class, Entitas.IComponent
  {
    int componentIndex = LookUpComponentIndex(entity, typeof(TComponent));
    if (componentIndex >= 0 && entity.HasComponent(componentIndex))
    {
      component = (TComponent)entity.GetComponent(componentIndex);
      return true;
    }

    component = default;
    return false;
  }

  public static void ReplaceComponent(this Entitas.IEntity entity, Entitas.IComponent component)
  {
    int componentIndex = LookUpComponentIndex(entity, component.GetType());
    if (componentIndex >= 0)
      entity.ReplaceComponent(componentIndex, component);
    else
      throw new System.Exception($""{nameof(entity.GetType)} do not support component: {nameof(component.GetType)}"");
  }

  public static bool TryReplaceComponent(this Entitas.IEntity entity, Entitas.IComponent component)
  {
    int componentIndex = LookUpComponentIndex(entity, component.GetType());
    if (componentIndex >= 0)
    {
      entity.ReplaceComponent(componentIndex, component);
      return true;
    }

    return false;
  }

  public static void RemoveComponent<TComponent>(this Entitas.IEntity entity, TComponent component)
    where TComponent : class, Entitas.IComponent => RemoveComponent(entity, component.GetType());

  public static void RemoveComponent(this Entitas.IEntity entity, System.Type componentType)
  {
    int componentIndex = LookUpComponentIndex(entity, componentType);
    if (componentIndex >= 0)
      entity.RemoveComponent(componentIndex);
    else
      throw new System.Exception($""{nameof(entity.GetType)} do not support component: {nameof(componentType)}"");
  }

  public static bool TryRemoveComponent<TComponent>(this Entitas.IEntity entity, TComponent component)
    where TComponent : class, Entitas.IComponent => TryRemoveComponent(entity, component.GetType());

  public static bool TryRemoveComponent(this Entitas.IEntity entity, System.Type componentType)
  {
    int componentIndex = LookUpComponentIndex(entity, componentType);
    if (componentIndex >= 0 && entity.HasComponent(componentIndex))
    {
      entity.RemoveComponent(componentIndex);
      return true;
    }

    return false;
  }
}
";
    
    public override CodeGenFile[] Generate(CodeGeneratorData[] data)
    {
      string matchers = string.Join("\n        ", data.OfType<ContextData>()
        .Select(context => 
          MatcherTemplate.Replace("${ContextName}", context.GetContextName())
          )
      );

      string ienityExtesions = IEntityExtensionTemplate.Replace("${Matchers}", matchers);
      
      List<CodeGenFile> files = new List<CodeGenFile>
      {
        new CodeGenFile(
          "Extensions" + Path.DirectorySeparatorChar + "IEntityExtensions.cs", 
          ienityExtesions, 
          GetType().FullName)
      };

      return files.ToArray();
    }
  }
}