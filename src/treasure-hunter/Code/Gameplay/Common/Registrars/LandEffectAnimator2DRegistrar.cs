using Code.Common.View.Registrars;
using Code.Gameplay.Character;
using Code.Gameplay.Common.Nodes;
using Entitas;
using Godot;

namespace Code.Gameplay.Common.Registrars;

[GlobalClass]
public partial class LandEffectAnimator2DRegistrar : LandEffectAnimator2D, IEntityNodeRegistrar
{
  public void Register(IEntity entity) => entity.AddComponent(new LandEffectAnimator2DComponent { Value = this });
  
  public void Unregister(IEntity entity) => entity.TryRemoveComponent<LandEffectAnimator2DComponent>();
}