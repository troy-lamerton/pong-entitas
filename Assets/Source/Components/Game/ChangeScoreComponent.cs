using Entitas;

[Game]
public class ChangeScoreComponent : IComponent {

	public int scoreOwnerId; // 0 for player, 1 for opponent (CPU)
	public int changeValue; //-1 or +1 to increment, 0 to reset score to zero
}
