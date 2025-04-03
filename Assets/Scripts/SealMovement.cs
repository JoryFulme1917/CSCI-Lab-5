using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealMovement : MonoBehaviour {

	public GameObject target;
	public float runSpeed;
	public float rotateSpeed;

	private float horizontal;
	private float vertical;
	private Rigidbody2D body;
	public GameObject blood;

	public Animator animator;
	private float currentSpeed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}

	private void FixedUpdate()
	{
		body.AddForce(transform.up * vertical * runSpeed);
		currentSpeed = vertical * runSpeed;
		animator.SetFloat("swimming", Mathf.Abs(currentSpeed));
		transform.Rotate(Vector3.back * horizontal * rotateSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject == target) {
			animator.SetBool("eating", true);
			Destroy(coll.gameObject);
			GameManager.Instance.IncScore(1);
			Instantiate(blood, coll.gameObject.transform.position, Quaternion.identity);
			GetComponent<AudioSource>().Play();
			Invoke("stopEating", 100);
		}
	}
	void stopEating(){
		animator.SetBool("eating", false);
	}
}
