﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: IState<PlayerYMovement> {
		
	public void EnterState(PlayerYMovement _owner) {
	}

	public void ExitState(PlayerYMovement _owner) {
	}

	public void UpdateState(PlayerYMovement _owner) {
		Debug.Log ("Falling...");
		if (!_owner.isJumping () && !_owner.isFalling ()) {
			_owner.stateMachine.ChangeState (_owner.dicYMovementStates[YMovementStates.IDLE]);
		}
	}
}
