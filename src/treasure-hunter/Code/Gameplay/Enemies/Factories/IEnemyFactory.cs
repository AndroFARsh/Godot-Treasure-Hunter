using Godot;

namespace Code.Gameplay.Enemies.Factories;

public interface IEnemyFactory
{
  GameEntity Create(EnemyName name, Vector2 at);
}