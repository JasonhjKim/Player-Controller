using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	Vector3 velocity;
	float gravity = -50f;
	RaycastHit2D hit;
	EnemyController controller;

	void Start () {
		controller = GetComponent<EnemyController> ();

	}

	void Update () {
		if (controller.collisions.below) {
			velocity.y = 0;
		}
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
