using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovementState :IState<PlayerMovement> {
	public void EnterState (PlayerMovement _owner) {
	}

	public void ExitState (PlayerMovement _owner) {
	}

	public void UpdateState (PlayerMovement _owner) {
		Debug.Log ("Idling...");
		if (_owner.isMoving ()) {
			_owner.stateMachine.ChangeState (_owner.listMovementStates [MovementStates.WALK]);
		}
		if (_owner.isJumping ()) {
			_owner.stateMachine.ChangeState (_owner.listMovementStates [MovementStates.JUMP]);
		}
	}
		
}
