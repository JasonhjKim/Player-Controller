using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYMovement : MonoBehaviour {
	public StateMachine<PlayerYMovement> stateMachine;
	public Dictionary<YMovementStates, IState<PlayerYMovement>> dicYMovementStates;
	PlayerController controller;
	PlayerBehaviour behaviour;


	// Use this for initialization
	void Start () {
		InitializeAllStates ();
		controller = GetComponent<PlayerController> ();
		stateMachine.ChangeState (dicYMovementStates[YMovementStates.IDLE]);
		behaviour = GetComponent<PlayerBehaviour> ();
	}

	// Update is called once per frame
	private void Update () {
		stateMachine.Update ();
	}

	public bool isGrounded(){
		if (controller.collisions.below) {
			return true;
		}
		return false;
	}

	public bool isJumping() {
		if (!controller.collisions.below && yDirection () > 0.9) {
			return true;
		}
		return false;
	}

	public bool isFalling() {
		if (!controller.collisions.below && yDirection () < -0.9) {
			return true;
		}
		return false;
	}


	private int yDirection() {
		float value = behaviour.currentVelocity().y;
		if (value < -0.9f) {
			return -1;
		} else if (value > 0.9f) {
			return  1;
		} else {
			return  0;
		}
	}

	private void InitializeAllStates() {
		stateMachine = new StateMachine<PlayerYMovement> (this);
		dicYMovementStates = new Dictionary<YMovementStates, IState<PlayerYMovement>> ();
		dicYMovementStates.Add (YMovementStates.FALL, new FallState ());
		dicYMovementStates.Add (YMovementStates.IDLE, new IdleYState ());
		dicYMovementStates.Add (YMovementStates.JUMP, new JumpState ());
	}
}

public enum YMovementStates {
	FALL,
	IDLE,
	JUMP
}
