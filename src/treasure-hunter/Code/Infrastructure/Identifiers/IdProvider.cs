namespace Code.Infrastructure.Identifiers
{
  public class IdProvider : IIdProvider
  {
    private ulong _lastId = 1;
    
    public ulong NextId => ++_lastId;
  }
}