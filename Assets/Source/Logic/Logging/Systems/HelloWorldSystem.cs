using Entitas;

public class HelloWorldSystem : IInitializeSystem {
	// keep a nice reference to the context
	// we interact with context a lot
	readonly GameContext _context;

	public HelloWorldSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		// create an entity and give it a debug msg component
		// and the Hello World! text string as data
		_context.CreateEntity ().AddDebugMessage ("Hellooo World!");
	}
}