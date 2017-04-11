using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AccelerateSystem : ReactiveSystem<InputEntity> {

	IGroup<GameEntity> _group;

	public AccelerateSystem(Contexts contexts) : base(contexts.input) {
		_group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Acceleratable, GameMatcher.Move));
	}

	protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context) {
		return context.CreateCollector(InputMatcher.Movement, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(InputEntity entity) {
		return entity.hasMovement;
	}

	protected override void Execute(List<InputEntity> entities) {
		foreach (InputEntity inputE in entities) {
			var direction = inputE.movement.direction;

			foreach(var e in _group.GetEntities()) {
				var move = e.move;
				float speed = move.maxSpeed * direction.y;
				e.ReplaceMove(speed, move.maxSpeed);
			}
		}
	}
}
