using Entitas;

namespace Code.Infrastructure.EntityFactories
{
  public interface IGroupBuilder<TEntity>
    where TEntity : class, IEntity
  {
    IGroupBuilder<TEntity> With<TComponent>() where TComponent : IComponent;
    
    IGroupBuilder<TEntity> Any<TComponent>() where TComponent : IComponent;
    
    IGroupBuilder<TEntity> Non<TComponent>() where TComponent : IComponent;
    
    IGroup<TEntity> Build();
  }
}