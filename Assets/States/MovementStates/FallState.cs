using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: IState<PlayerMovement> {
		
	public void EnterState(PlayerMovement _owner) {
	}

	public void ExitState(PlayerMovement _owner) {
	}

	public void UpdateState(PlayerMovement _owner) {
		Debug.Log ("Falling...");
		if (!_owner.isFalling () && !_owner.isMoving()) {
			_owner.stateMachine.ChangeState (_owner.listMovementStates [MovementStates.IDLE]);
		}

	}
}
