namespace Code.Infrastructure.Physics;

public interface IEntityResolverFromCollider
{
  TEntity Resolve<TEntity>(ulong instanceId) where TEntity : class;
}