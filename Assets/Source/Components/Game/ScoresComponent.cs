using Entitas;
using Entitas.CodeGenerator.Api;

[Game, Unique]
public sealed class ScoresComponent : IComponent {

	public int[] scores = new int[] { 0, 0 };
}
