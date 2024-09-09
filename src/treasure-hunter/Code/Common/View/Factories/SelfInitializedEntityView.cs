using System.Linq;
using Entitas;
using Godot;
using TreasureHunter.Code.Common.View;

namespace Code.Common.View.Factories
{
  public abstract partial class SelfInitializedEntityView<TEntity> : Node
    where TEntity : class, IEntity
  {
    [Export] private EntityViewNode _entityViewNode;

    public override void _Ready()
    {
        if (TryGetEntityViewNode(out IEntityView entityView))
        {
          Context<TEntity> context = GetContext();
          if (context != null)
            entityView.Retain(context.CreateEntity());
        }
    }
    
    private static Context<TEntity> GetContext() =>
        Contexts.sharedInstance.allContexts.OfType<Context<TEntity>>().FirstOrDefault();

      private bool TryGetEntityViewNode(out IEntityView viewNode)
      {
        viewNode = _entityViewNode ?? FindChildren("*", nameof(EntityViewNode)).FirstOrDefault((Node)null) as IEntityView;
        return viewNode != null;
      }
    }
  }