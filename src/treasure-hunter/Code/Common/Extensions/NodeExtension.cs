using System.Collections.Generic;
using Godot;

namespace Code.Common.Extensions;

public static class NodeExtension
{
  public static TNode FindChildOfType<TNode>(this Node node) where TNode: Node
  {
    if (node == null) return null;
    if (node is TNode tnode) return tnode;

    foreach (Node child in node.GetChildren())
    {
      TNode tchild = FindChildOfType<TNode>(child);
      if (tchild != null) return tchild;
    }

    return null;
  }

  public static List<T> FindChildrenOfType<T>(this Node node)
  {
    List<T> result = new();
    node.FindChildrenOfType(result);
    return result;
  }

  public static int FindChildrenOfType<T>(this Node node, List<T> result)
  {
    if (node == null) return 0;

    int count = 0;
    if (node is T tnode)
    {
      result.Add(tnode);
      count++;
    }

    foreach (Node child in node.GetChildren())
      count += FindChildrenOfType(child, result);

    return count;
  }
}