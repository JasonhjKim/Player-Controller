using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class IdleState :State<PSM> {
	public static IdleState _instance;
	private IdleState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static IdleState Instance {
		get {
			if (_instance == null) {
				new IdleState ();
			}
			return _instance;
		}
	}

	public override void EnterState (PSM _owner) {
		Debug.Log ("Entering Idle State");
	}

	public override void ExitState (PSM _owner) {
		Debug.Log ("Exiting Idle State");
	}

	public override void UpdateState (PSM _owner) {
		if (_owner.isFalling()) {
			_owner.stateMachine.ChangeState (FallState.Instance);
		}
		if (_owner.isJumping ()) {
			_owner.stateMachine.ChangeState (JumpState.Instance);
		}
		if (_owner.isMoving ()) {
			_owner.stateMachine.ChangeState (WalkState.Instance);
		}
	}
		
}
