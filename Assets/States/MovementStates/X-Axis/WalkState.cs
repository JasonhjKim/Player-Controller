using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState<PlayerXMovement> {
	public void EnterState(PlayerXMovement _owner) {
	}

	public void ExitState(PlayerXMovement _owner) {
	}

	public void UpdateState(PlayerXMovement _owner) {
		Debug.Log ("Moving");
		if (!_owner.isMoving ()) {
			_owner.stateMachine.ChangeState (_owner.dicXMovementStates [XMovementStates.IDLE]);
		}
	}

}
