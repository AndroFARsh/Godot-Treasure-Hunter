using System;
using Code.Common.Extensions;
using Code.Infrastructure.LifeTime;
using Godot;
using Ninject;

namespace Code.Projects;

public partial class Project : Node
{
  private StandardKernel _kernel = new();
  
  public override void _Ready()
  {
    _kernel = new StandardKernel()
      .With(k => k.Load(AppDomain.CurrentDomain.GetAssemblies()))
      .With(k => k.ResolveDependencies(this));
    
    _kernel.Get<ILifeTime>().Start();
  }

  public override void _PhysicsProcess(double delta) => _kernel?.Get<ILifeTime>().Tick(delta);
  
  // public override void _Process(double delta) => _kernel?.Get<ILifeTime>().Tick(delta);

  public override void _Notification(int what)
  {
    if (what == NotificationPredelete)
    {
      _kernel.Get<ILifeTime>().Stop();
      _kernel.Dispose();
      _kernel = null;
      
      GetParent()?.RemoveChild(this);
      QueueFree();
    }
  }
}