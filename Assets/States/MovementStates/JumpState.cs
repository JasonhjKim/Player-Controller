using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState<PlayerMovement> {
	public void EnterState(PlayerMovement _owner) {
	}

	public void ExitState(PlayerMovement _owner) {
	}

	public void UpdateState(PlayerMovement _owner) {
		Debug.Log ("Jumping....");
		if (!_owner.isJumping () && _owner.isFalling ()) {
			_owner.stateMachine.ChangeState (_owner.listMovementStates [MovementStates.FALL]);
		}
	}

}

