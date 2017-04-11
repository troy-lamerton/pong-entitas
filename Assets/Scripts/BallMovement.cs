using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(-4f, -1.2f);
	}
	
	// Update is called once per frame
	void Update () {
//		this.transform.position = new Vector3(Random.Range (-6, 6), Random.Range (-4, 4), 0);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Paddle") {
			rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y * 1.1f);
		}
	}
}
