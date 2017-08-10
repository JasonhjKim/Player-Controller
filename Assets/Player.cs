using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class Player : MonoBehaviour {
	public StateMachine<Player> stateMachine;
	private Dictionary<States, IState<Player>> listStates;
	PlayerController controller;
	PlayerBehaviour behaviour;
	public bool fallingFinish;


	// Use this for initialization
	void Start () {
		InitializeAllStates ();
		controller = GetComponent<PlayerController> ();
		stateMachine.ChangeState (listStates[States.IDLE]);
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
		stateMachine = new StateMachine<Player> (this);
		listStates = new Dictionary<States, IState<Player>> ();
		listStates.Add (States.FALL, new FallState ());
		listStates.Add (States.IDLE, new IdleState ());
		listStates.Add (States.JUMP, new JumpState ());
		listStates.Add (States.RUN, new RunState ());
		listStates.Add (States.WALK, new WalkState ());
	}
}

public enum States {
	FALL,
	IDLE,
	JUMP,
	RUN,
	WALK
}
	