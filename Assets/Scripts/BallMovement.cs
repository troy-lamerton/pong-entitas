using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	GameContext _context;
	Rigidbody2D rb;
	public float startingSpeed = 4f;
	// Use this for initialization
	void Start () {
		_context = Contexts.sharedInstance.game;
		rb = this.GetComponent<Rigidbody2D> ();

		rb.velocity = new Vector2(-10f, -3f);
		rb.velocity = Vector2.ClampMagnitude (rb.velocity, startingSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		
		string oTag = coll.gameObject.tag;
		string oName = coll.gameObject.name;

		if (oTag == "Paddle" | oTag == "Boundary") {
			_context.CreateEntity ()
				.AddCollider (this.gameObject, coll.gameObject);
		}
	}
}
