using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class WalkState : State<PSM> {
	public static WalkState _instance;
	private WalkState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static WalkState Instance {
		get { 
			if (_instance == null) {
				new WalkState ();
			}
			return _instance;
		}
	}

	public override void EnterState(PSM _owner) {
		Debug.Log ("Entering Walking State");
	}

	public override void ExitState(PSM _owner) {
		Debug.Log ("Exiting Walking State");
	}

	public override void UpdateState(PSM _owner) {
		Debug.Log ("Walking...");
		if (!_owner.isMoving()) {
			_owner.stateMachine.ChangeState (IdleState.Instance);
		}
	}

}
