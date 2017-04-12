using Entitas;

public class GameSystems : Feature {
	public GameSystems(Contexts contexts) : base("Game Systems") {
		
		Add (new AccelerateSystem (contexts));
		Add (new AccelerateTowardsSystem (contexts));
		Add (new MoveSystem (contexts));
		Add (new CollisionSystem (contexts));
	}
}
