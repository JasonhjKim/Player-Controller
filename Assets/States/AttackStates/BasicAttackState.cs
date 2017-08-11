using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackState: IState<PlayerAttack> {

	public void EnterState(PlayerAttack _owner) {
	}

	public void ExitState(PlayerAttack _owner) {
	}

	public void UpdateState(PlayerAttack _owner) {
		Debug.Log ("Attacked...");
		_owner.stateMachine.ChangeState (_owner.listAttackStates [AttackStates.IDLE]);
	}
}
