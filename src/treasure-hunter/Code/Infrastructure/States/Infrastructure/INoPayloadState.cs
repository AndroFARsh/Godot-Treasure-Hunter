namespace Code.Infrastructure.States.Infrastructure
{
  public interface INoPayloadState : IState
  {
    void Enter();
  }
}