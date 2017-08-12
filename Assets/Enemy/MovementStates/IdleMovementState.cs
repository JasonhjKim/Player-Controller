using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovementState: IState<Enemy> {
	public void EnterState(Enemy _owner) {
		Debug.Log ("Entering Idling State");
	}

	public void ExitState(Enemy _owner) {
		Debug.Log ("Exiting Idling State");
	}

	public void UpdateState(Enemy _owner) {
		if (_owner.isChasing && !_owner.isIdling) {
			_owner.stateMachine.ChangeState (_owner.dicEnemyMovementStates [EnemyMovementStates.CHASE]);
		}
	}


}
