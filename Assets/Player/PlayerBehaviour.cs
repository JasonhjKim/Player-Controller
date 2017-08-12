using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerBehaviour : MonoBehaviour {
	PlayerController controller;
	public float jumpHeight = 4;
	public float timeToJumpApex = 0.4f;
	public float moveSpeed = 6;

	float accelerationTimeAirborne = 0.01f;
	float accelerationTimeGrounded = 0.1f;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		gravity = -((2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2));
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		Debug.Log ("Gravity: " + gravity + " " + "Jump Velocity: " + jumpVelocity);

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (controller.collisions.below) {
			velocity.y = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}
//		Debug.Log (Mathf.Sign (velocity.y));
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeAirborne:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime);
	}

	public Vector3 currentVelocity() {
		return velocity;
	}
}
