using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Code.Infrastructure.Physics;
using Entitas;
using Godot;
using Ninject;

namespace Code.Common.View;

[GlobalClass]
public partial class EntityViewNode : Node, IEntityView
{
  private IEntity _entity;
  private IColliderToEntityRegistry _colliderRegistry;

  public string PoolKey => GetSceneFilePath();
    
  public Node Node => this;
    
  [Inject]
  public void Construct(IColliderToEntityRegistry colliderRegistry)
  {
    _colliderRegistry = colliderRegistry;
  }
    
  public void Retain(IEntity entity)
  {
    _entity = entity;
    _entity.AddComponent(new ViewComponent { Value = this });
    _entity.Retain(this);

    foreach (IEntityNodeRegistrar registrar in this.FindChildrenOfType<IEntityNodeRegistrar>())
      registrar.Register(_entity);

    foreach (CollisionObject2D collisionObject2D in this.FindChildrenOfType<CollisionObject2D>())
      _colliderRegistry.Register(collisionObject2D.GetInstanceId(), _entity);
  }

  public void Release()
  {
    foreach (IEntityNodeRegistrar registrar in this.FindChildrenOfType<IEntityNodeRegistrar>())
      registrar.Unregister(_entity);
     
    foreach (CollisionObject2D collisionObject2D in this.FindChildrenOfType<CollisionObject2D>())
      _colliderRegistry.Unregister(collisionObject2D.GetInstanceId());
      
    _entity.Release(this);
    _entity = null;
  }
}