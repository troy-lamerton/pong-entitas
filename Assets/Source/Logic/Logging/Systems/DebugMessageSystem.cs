using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugMessageSystem : ReactiveSystem<GameEntity> {
	public DebugMessageSystem(Contexts contexts) : base(contexts.game) {
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context){
		// just enetites with DebugMessageComponent
		return context.CreateCollector (GameMatcher.DebugMessage);
	}

	protected override bool Filter(GameEntity entity) {
		// final check of the entites, just in case 
		// the entity was modified in a different system leading up to this one 
		return entity.hasDebugMessage;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach(var e in entities) {
			// woohoo we got the entities that match our matcher and filter 
			// entity variable | component name | property
			Debug.Log(e.debugMessage.message);
		}
	}
}
