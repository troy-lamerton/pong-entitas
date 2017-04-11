using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class CollisionSystem : ReactiveSystem<GameEntity>, ICleanupSystem {

	readonly IGroup<GameEntity> _group;
	readonly GameContext _context;

	public CollisionSystem(Contexts contexts) : base(contexts.game) {
		_context = contexts.game;
		_group = contexts.game.GetGroup(GameMatcher.Collider);
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Collider);
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasCollider;
	}

	protected override void Execute(List<GameEntity> entities) {

		foreach(GameEntity e in entities) {
			GameObject gameObjectA = e.collider.me;
			GameObject gameObjectB = e.collider.other;

			Rigidbody2D rb = gameObjectA.GetComponent<Rigidbody2D> ();

			if (gameObjectB.tag == "Boundary") {
				var newAsset = Resources.Load<GameObject> ("Explosion");
				GameObject explosion = null;
				try {
					explosion = UnityEngine.Object.Instantiate (newAsset);
				} catch (Exception) {
					Debug.Log ("Cannot instantiate 'Explosion'");
				}
				if (explosion != null) {
					explosion.transform.position = gameObjectA.transform.position;
					UnityEngine.Object.Destroy (explosion, 0.35f);
				}
				// reset ball
				gameObjectA.transform.position = Vector2.zero;

				if (gameObjectB.name.EndsWith ("Player")) {
					_context.CreateEntity ()
						.AddChangeScore (1, +1);
				} else if (gameObjectB.name.EndsWith ("Opponent")) {
					_context.CreateEntity ()
						.AddChangeScore (0, +1);
				}

				Vector2 startV = new Vector2 (-5f, -1.5f);
				startV = Vector2.ClampMagnitude (startV, 4f);
				rb.velocity = new Vector2 (
					startV.x * Mathf.Sign (gameObjectB.transform.position.x),
					startV.y * UnityEngine.Random.Range (-2, 2) * 0.7f 
				);
			}
			else if (gameObjectB.tag == "Paddle") {
				// increase velocity when ball hits paddle
				rb.velocity = new Vector2(rb.velocity.x * 1.13f, rb.velocity.y * 1.13f);
			}
		}
	}

	public void Cleanup() {
		// destroy all entites with the collsion component
		foreach (GameEntity e in _group.GetEntities()) {
			_context.DestroyEntity(e);
		}
	}
}
