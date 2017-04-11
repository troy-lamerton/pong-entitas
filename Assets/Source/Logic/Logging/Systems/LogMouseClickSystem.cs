using Entitas;
using UnityEngine;

public class LogMouseClickSystem : IExecuteSystem {

	readonly GameContext _context;

	public LogMouseClickSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Execute() {
		if (Input.GetMouseButtonDown(0)) {
			_context.CreateEntity ().AddDebugMessage ("Left MB click");
		}

		if (Input.GetMouseButtonDown(1)) {
			_context.CreateEntity ().AddDebugMessage ("Right MB click");
		}
	}
}
