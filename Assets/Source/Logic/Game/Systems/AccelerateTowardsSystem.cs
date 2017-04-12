using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AccelerateTowardsSystem : IExecuteSystem {

	IGroup<GameEntity> _group;

	public AccelerateTowardsSystem(Contexts contexts) {
		_group = contexts.game.GetGroup (GameMatcher.AccelerateTowards);
	}

	public bool Filter(GameEntity entity) {
		return entity.hasMove & entity.hasAccelerateTowards;
	}

	public void Execute() {
		foreach (GameEntity e in _group.GetEntities()) {
			float activeRange = e.accelerateTowards.activeRange;
			if (activeRange > 0) {
				GameObject target = null;
				target = GameObject.FindGameObjectWithTag (e.accelerateTowards.targetTag);

				if (target != null) {
					Vector2 targetPosition = target.transform.position;
					float distanceToTarget = Mathf.Abs (Vector2.Distance (new Vector2 (e.position.x, e.position.y), targetPosition));
					float yDistanceToTarget = Mathf.Abs (e.position.y - targetPosition.y);

					if (yDistanceToTarget <= 0.5f) {
						e.ReplaceMove (0, e.move.maxSpeed);
					}
					else if (distanceToTarget <= activeRange || yDistanceToTarget > 6f) {
						// in range
						float yDirectionToTarget = (targetPosition.y > e.position.y) ? 1 : -1;
						float speedValue = e.move.maxSpeed * Mathf.Sign (yDirectionToTarget);
						e.ReplaceMove (speedValue, e.move.maxSpeed);
					}
					else if (Mathf.Abs(e.position.y) > 1f) {
						// paddle is far from middle
						// move towards middle
						e.ReplaceMove (e.move.maxSpeed * Mathf.Sign(e.position.y) * -1, e.move.maxSpeed);
					}
					else {
						e.ReplaceMove (0, e.move.maxSpeed);
					}
				}
			}
		}
	}
}
