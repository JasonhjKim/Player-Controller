using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class FallState: State<PSM> {
	public static FallState _instance;
	private FallState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static FallState Instance {
		get { 
			if (_instance == null) {
				new FallState ();
			}
			return _instance;
		}
	}
		
	public override void EnterState(PSM _owner) {
		Debug.Log ("Entering Falling State");
	}

	public override void ExitState(PSM _owner) {
		Debug.Log ("Exiting Falling State");
	}

	public override void UpdateState(PSM _owner) {
		Debug.Log ("Falling....");
		if (_owner.isFalling() && !_owner.isJumping()) {
			_owner.stateMachine.ChangeState (IdleState.Instance);
		}
	}
}
