using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

	Systems _systems;

	Systems createSystems(Contexts contexts) {
		return new Feature ("Systems")
			.Add (new InitSystems (contexts))
			.Add (new InputSystem (contexts))
			.Add (new GameSystems (contexts))
			.Add (new ViewSystems (contexts));
		
	}

	void Start () {
		var contexts = Contexts.sharedInstance;

		_systems = createSystems (contexts);

		// call Initialize on all the IInitalizeSystems
		_systems.Initialize ();
	}

	void Update () {
		// call Execute() on all the IexecuteSystems and
		// ReactiveSystems that were triggered last frame
		_systems.Execute ();
		// call cleanup on all the ICleanupSystems
		_systems.Cleanup ();
	}
}
