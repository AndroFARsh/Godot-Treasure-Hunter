namespace Code.Infrastructure.Physics
{
  public interface IEntityResolverFromCollider
  {
    TEntity Resolve<TEntity>(int instanceId) where TEntity : class;
  }
}