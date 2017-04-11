using System.Collections;
using System.Collections.Generic;
using Entitas;

public class InitPlayerSystem : IInitializeSystem {
	
	GameContext _context;

	public InitPlayerSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var e = _context.CreateEntity();
		e.AddAsset("Paddle");
		e.AddPosition(-5, 0);
		e.AddMove(0, 0.025f);
		e.isAcceleratable = true;
	}
}
