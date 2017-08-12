using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXMovement : MonoBehaviour {
	public StateMachine<PlayerXMovement> stateMachine;
	public Dictionary<XMovementStates, IState<PlayerXMovement>> dicXMovementStates;
	PlayerController controller;
	PlayerBehaviour behaviour;


	// Use this for initialization
	void Start () {
		InitializeAllStates ();
		controller = GetComponent<PlayerController> ();
		stateMachine.ChangeState (dicXMovementStates[XMovementStates.IDLE]);
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

	public bool isMoving() {
		if (xDirection() < -0.9 || xDirection() > 0.9) {
			return true;
		}
		return false;
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
		stateMachine = new StateMachine<PlayerXMovement> (this);
		dicXMovementStates = new Dictionary<XMovementStates, IState<PlayerXMovement>> ();
		dicXMovementStates.Add (XMovementStates.IDLE, new IdleXState ());
		dicXMovementStates.Add (XMovementStates.RUN, new RunState ());
		dicXMovementStates.Add (XMovementStates.WALK, new WalkState ());
	}
}

public enum XMovementStates {
	IDLE,
	RUN,
	WALK
}
	