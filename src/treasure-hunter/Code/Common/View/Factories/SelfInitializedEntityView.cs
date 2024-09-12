using System.Linq;
using Entitas;

namespace Code.Common.View.Factories;

public abstract partial class SelfInitializedEntityView<TEntity> : EntityViewNode
  where TEntity : class, IEntity
{
  public override void _Ready()
  {
    Context<TEntity> context = GetContext();
    if (context != null)
      Retain(context.CreateEntity());
  }

  private static Context<TEntity> GetContext() =>
    Contexts.sharedInstance.allContexts.OfType<Context<TEntity>>().FirstOrDefault();
}