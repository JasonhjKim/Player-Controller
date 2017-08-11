using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public StateMachine<PlayerMovement> stateMachine;
	public Dictionary<MovementStates, IState<PlayerMovement>> listMovementStates;
	PlayerController controller;
	PlayerBehaviour behaviour;
	public bool fallingFinish;


	// Use this for initialization
	void Start () {
		InitializeAllStates ();
		controller = GetComponent<PlayerController> ();
		stateMachine.ChangeState (listMovementStates[MovementStates.IDLE]);
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

	public bool isMoving() {
		if (xDirection() < -0.9 || xDirection() > 0.9) {
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

	private int xDirection() {
		float value = behaviour.currentVelocity().x;
		if (value < -0.9f) {
			return -1;
		} else if (value > 0.9f) {
			return  1;
		} else {
			return  0;
		}
	}

	private void InitializeAllStates() {
		stateMachine = new StateMachine<PlayerMovement> (this);
		listMovementStates = new Dictionary<MovementStates, IState<PlayerMovement>> ();
		listMovementStates.Add (MovementStates.FALL, new FallState ());
		listMovementStates.Add (MovementStates.IDLE, new IdleMovementState ());
		listMovementStates.Add (MovementStates.JUMP, new JumpState ());
		listMovementStates.Add (MovementStates.RUN, new RunState ());
		listMovementStates.Add (MovementStates.WALK, new WalkState ());
	}
}

public enum MovementStates {
	FALL,
	IDLE,
	JUMP,
	RUN,
	WALK
}
	