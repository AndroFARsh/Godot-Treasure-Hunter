using System.Linq;
using Godot;
using Ninject.Parameters;
using Ninject.Syntax;

namespace Code.Common.Extensions;

public static class DIExtensions
{
  public static Node ResolveDependencies(this IResolutionRoot resolutionRoot, Node node, params IParameter[] args)
  {
    if (node != null)
    {
      resolutionRoot.Inject(node, args);
      foreach (Node child in node.GetChildren())
        ResolveDependencies(resolutionRoot, child, args);
    }

    return node;
  }
}