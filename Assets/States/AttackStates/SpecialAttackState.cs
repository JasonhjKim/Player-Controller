using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackState: IState<PlayerAttack> {
	public void EnterState(PlayerAttack _owner) {
	}

	public void ExitState(PlayerAttack _owner) {
	}

	public void UpdateState(PlayerAttack _owner) {
		Debug.Log ("Special Attacking...");
		_owner.stateMachine.ChangeState (_owner.listAttackStates [AttackStates.IDLE]);
	}
}
