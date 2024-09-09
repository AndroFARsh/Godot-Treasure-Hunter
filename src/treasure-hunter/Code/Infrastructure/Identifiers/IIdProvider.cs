namespace Code.Infrastructure.Identifiers
{
  public interface IIdProvider
  {
    const ulong InvalidId = 0;
    
    ulong NextId { get; }
  }
}