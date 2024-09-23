using System;
using System.Reflection;
using Code.Infrastructure.LifeTime;
using Code.Projects.Modules;
using Godot;
using Ninject;

namespace Code.Projects;

public partial class Project : Node, IProject
{
  private StandardKernel _kernel = new();
  
  [Export] public Node SceneRoot { get; private set; }
  [Export] public ColorRect Curtain { get; private set; }
  
  public override void _Ready()
  {
    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

    _kernel.Bind<IProject>().ToConstant(this);
    _kernel.Load(assemblies);
    
    _kernel.Get<ILifeTime>().Start();
  }
  
  public override void _Notification(int what)
  {
    if (what == NotificationPredelete)
    {
      Contexts.sharedInstance.Reset();
      
      _kernel.Get<ILifeTime>().Stop();
      _kernel.Dispose();
      _kernel = null;
    }
  }

  public override void _Process(double delta) =>_kernel.Get<ILifeTime>().Tick(delta);

  public void Quit() => GetTree().Quit();
}