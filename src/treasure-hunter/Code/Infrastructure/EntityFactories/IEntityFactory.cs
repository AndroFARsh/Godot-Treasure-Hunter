using Entitas;

namespace Code.Infrastructure.EntityFactories
{
  public interface IEntityFactory
  {
    TEntity CreateEntity<TEntity>() where TEntity : class, IEntity;
    
    IGroup<TEntity> CreateGroup<TEntity>(IMatcher<TEntity> matcher) where TEntity : class, IEntity;
    
    IGroupBuilder<TEntity> BuildGroup<TEntity>() where TEntity : class, IEntity;
  }
}