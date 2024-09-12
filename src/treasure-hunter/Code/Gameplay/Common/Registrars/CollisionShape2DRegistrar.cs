using Code.Common.Extensions;
using Code.Common.View.Registrars;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class CollisionShape2DRegistrar : EntityNodeRegistrar<GameEntity>
{
  [Export] private CollisionShape2D _collisionShape2D;

  public override void Register(GameEntity entity)
  {
    _collisionShape2D ??= GetParent().FindChildOfType<CollisionShape2D>();
    if (_collisionShape2D != null) entity.AddCollisionShape2D(_collisionShape2D);
  }

  public override void Unregister(GameEntity entity)
  {
    if (entity.hasCollisionShape2D) entity.RemoveCollisionShape2D();
  }

  
}