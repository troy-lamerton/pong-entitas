using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitBallSystem : IInitializeSystem {

	GameContext _context;

	public InitBallSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var e = _context.CreateEntity();
		e.AddAsset("Ball");
	}
}
