namespace Code.Infrastructure.States.Infrastructure
{
  public interface IPayloadState<TPayload> : IState
  {
    void Enter(TPayload payload);
  }
}