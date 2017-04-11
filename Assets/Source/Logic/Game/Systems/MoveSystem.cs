using UnityEngine;
using Entitas;
using System;

public sealed class MoveSystem : IExecuteSystem {

	readonly IGroup<GameEntity> _group;

	public MoveSystem(Contexts contexts) {
		_group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Move, GameMatcher.Position));
	}

	public void Execute() {
		foreach (var e in _group.GetEntities()) {
			var move = e.move;
			var pos = e.position;

			float newPosX = pos.x;
			float newPosY = pos.y;

			if (e.hasLimitPosition) {
				Vector2 min = e.limitPosition.min;
				Vector2 max = e.limitPosition.max;
				newPosX = Mathf.Clamp (pos.x, min.x, max.x);
				newPosY = Mathf.Clamp (pos.y, min.y, max.y);
			}

			e.ReplacePosition(newPosX, newPosY + move.speed);
		}
	}
}

