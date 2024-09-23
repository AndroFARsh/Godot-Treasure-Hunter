using Code.Common.View.Factories;
using Entitas;

namespace Code.Common.CleanUp.Systems;

public class CeanaupPoolSystem : ITearDownSystem 
{
	private readonly IEntityViewPool _pool;

	public CeanaupPoolSystem(IEntityViewPool pool)
	{
		_pool = pool;
	}

	public void TearDown() => _pool.CleanUp();
}