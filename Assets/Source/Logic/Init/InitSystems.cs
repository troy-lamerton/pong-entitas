using Entitas;

public class InitSystems : Feature {
	public InitSystems (Contexts contexts) {
		Add (new InitPlayerSystem(contexts));
		Add (new InitOpponentSystem (contexts));
		Add (new InitBallSystem (contexts));
		Add (new InitScoresSystem (contexts));
	}
}
