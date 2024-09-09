using Code.Infrastructure.LifeTime;
using Code.Infrastructure.States;
using Code.Projects.States;

namespace Code.Projects.EntryPoint;

public class ProjectEntryPoint : IStartable
{
  private readonly IStateMachine _stateMachine;

  public ProjectEntryPoint(IStateMachine stateMachine)
  {
    _stateMachine = stateMachine;
  }

  public void Start() => _stateMachine.Enter<BootstrapState>();
}