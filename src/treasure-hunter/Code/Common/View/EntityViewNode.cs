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
 
    // foreach (Collider2D collider2d in gameObject.GetComponentsInChildren<Collider2D>(true))
    //   _colliderRegistry.Register(collider2d.GetInstanceID(), _entity);
  }

  public void Release()
  {
    foreach (IEntityNodeRegistrar registrar in this.FindChildrenOfType<IEntityNodeRegistrar>())
      registrar.Unregister(_entity);
      
    //this.FindChildren()
    // foreach (Collider2D collider2d in gameObject.GetComponentsInChildren<Collider2D>(true))
    //   _colliderRegistry.Unregister(collider2d.GetInstanceID());
      
    _entity.Release(this);
    _entity = null;
  }
}