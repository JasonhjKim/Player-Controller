using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class JumpState : State<PSM> {
	public static JumpState _instance;
	private JumpState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static JumpState Instance {
		get { 
			if (_instance == null) {
				new JumpState ();
			}
			return _instance;
		}
	}

	public override void EnterState(PSM _owner) {
		Debug.Log ("Entering Jumping State");
	}

	public override void ExitState(PSM _owner) {
		Debug.Log ("Exiting Jumping State");
	}

	public override void UpdateState(PSM _owner) {
		Debug.Log ("Jumping....");
		if (!_owner.isGrounded() && !_owner.isJumping ()) {
			_owner.stateMachine.ChangeState (FallState.Instance);
		}
	}

}

