using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem, ICleanupSystem {

	readonly InputContext _context;

	public InputSystem(Contexts contexts) {
		_context = contexts.input;
	}

	public void Execute() {
		float rawVerticalInput = Input.GetAxisRaw ("Vertical");

		int verticalDirection = (rawVerticalInput > 0) ? 1 : -1;
		if (rawVerticalInput == 0) {
			verticalDirection = 0;
		}
		Vector2 direction = new Vector2 (0, verticalDirection);
		_context.CreateEntity ()
			.AddMovement (direction);
	}

	public void Cleanup() {
		foreach(var e in _context.GetEntities()) {
			_context.DestroyEntity (e);
		}
	}
}
