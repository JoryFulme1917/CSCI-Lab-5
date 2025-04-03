using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSteer : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float rotationSpeed;

	public Rigidbody2D body;

	public Animator animator;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 desired = (target.transform.position - transform.position).normalized;
		body.AddForce(desired * speed - body.linearVelocity);
		if(Mathf.Abs(body.linearVelocity.x) > 0){
			animator.SetFloat("Swim", Mathf.Abs(body.linearVelocity.x));
		}
		else{
			animator.SetFloat("Swim", Mathf.Abs(body.linearVelocity.y));
		}

		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg);
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation,
			q, Time.deltaTime * rotationSpeed);

	}

	public void IncreaseSpeed() {
		speed *= 1.2f;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Vector3 direction = body.linearVelocity;
		Gizmos.DrawRay(transform.position, direction);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		animator.SetBool("Eat", true);
		if (coll.gameObject == target) {
			GetComponent<AudioSource>().Play();
			Initiate.Fade("Death Screen", Color.red, 1.0f);
			Invoke("DoneEat", 1);
		}
	}

	void DoneEat(){
		animator.SetBool("Eat", false);
	}
}
