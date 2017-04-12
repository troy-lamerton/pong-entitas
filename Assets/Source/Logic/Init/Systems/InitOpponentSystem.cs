using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitOpponentSystem : IInitializeSystem {

	GameContext _context;

	public InitOpponentSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		float x = 6;
		var e = _context.CreateEntity();
		e.AddPosition(x, 0);
		e.AddMove(0, 0.06f);
		float limitY = 3.1f;
		e.AddLimitPosition (new Vector2 (x, -limitY), new Vector2 (x, limitY));
		e.AddAsset("Paddle");
		e.AddAccelerateTowards ("Ball", 7f);
	}
}
