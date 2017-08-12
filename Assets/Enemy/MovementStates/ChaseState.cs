using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState: IState<Enemy> {
	
	public void EnterState(Enemy _owner) {
		Debug.Log ("Entering Chasing State");
	}

	public void ExitState(Enemy _owner) {
		Debug.Log ("Exiting Chasing State");
	}

	public void UpdateState(Enemy _owner) {
		if (!_owner.DirectionChecker (_owner.DirectionFromTarget ())) {
			_owner.Rotate ();
		}

		if (_owner.DistanceFromTarget() >= 1.0f) {
//			_owner.transform.position.x = new Vector2 (Vector2.MoveTowards (_owner.transform.position, _owner.target.transform.position, _owner.chaseSpeed * Time.deltaTime), 0);
		}

		if (_owner.DistanceFromTarget () > _owner.chaseOutofRange) {
			Debug.Log (_owner.DistanceFromTarget ());
			Debug.Log ("Out of Range: Back to Idle");
			_owner.stateMachine.ChangeState (_owner.dicEnemyMovementStates [EnemyMovementStates.IDLE]);
			_owner.isChasing = false;
			_owner.isIdling = true;
		}
	}
}
