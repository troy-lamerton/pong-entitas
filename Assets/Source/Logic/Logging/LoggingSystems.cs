using Entitas;

public class TutorialSystems : Feature {
	public TutorialSystems(Contexts contexts) {
		Add (new HelloWorldSystem (contexts));
		Add (new LogMouseClickSystem (contexts));
		Add (new DebugMessageSystem (contexts));
		Add (new CleanupDebugMesageSystem (contexts));
	}
}
