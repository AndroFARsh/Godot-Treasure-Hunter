using System;
using Godot;

namespace Code.Projects.Providers.Game;

public class GameRootProvider : IGameRootProvider, IDisposable
{
  public Node2D Root { get; private set; }

  public void Retain(Node2D node) => Root = node;
  
  public void Release() => Root = null;

  public void Dispose() => Release();
}