﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSteer : MonoBehaviour {

	public float speed;
	public GameObject target;
	public GameObject shark;
	public static float minDist;

	private bool tagged;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (target) {
			Vector2 desired = target.transform.position - transform.position;

			if (desired.magnitude < minDist) {
				print("avoiding seal");
				float actual = desired.magnitude - minDist;
				body.AddForce(desired.normalized *
					actual * speed - body.linearVelocity);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (!tagged && coll.gameObject == target) {
			print("seal!");
			shark.GetComponent<FollowSteer>().IncreaseSpeed();
			minDist += 2;
			tagged = true;
		}

	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Vector3 direction = GetComponent<Rigidbody2D>().linearVelocity;
		Gizmos.DrawRay(transform.position, direction);
		Gizmos.DrawWireSphere(transform.position, minDist);
	}
}
