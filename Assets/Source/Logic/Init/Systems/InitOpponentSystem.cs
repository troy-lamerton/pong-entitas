using System.Collections;
using System.Collections.Generic;
using Entitas;

public class InitOpponentSystem : IInitializeSystem {

	GameContext _context;

	public InitOpponentSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var e = _context.CreateEntity();
		e.AddPosition(5, 0);
		e.AddMove(0, 0.025f);
		e.AddAsset("Paddle");
	}
}
