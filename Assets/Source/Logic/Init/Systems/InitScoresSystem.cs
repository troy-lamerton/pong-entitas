using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitScoresSystem : IInitializeSystem {

	GameContext _context;

	public InitScoresSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var e = _context.CreateEntity();
		e.AddScores (new int[]{0, 0});
	}
}
