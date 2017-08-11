using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAttackState: IState<PlayerAttack> {
	private float attackCooldown = 3f;
	private float specialAttackCooldown = 5f;
	private float nextAttack;
	private float nextSpecialAttack;
	private float gametimer;
	private float seconds = 0;
	private bool basicNotification = true;
	private bool specialNotification = true;
	public void EnterState(PlayerAttack _owner) {
	}

	public void ExitState(PlayerAttack _owner) {
	}

	public void UpdateState(PlayerAttack _owner) {
		if (Time.time > gametimer + 1) {
			gametimer = Time.time;
			seconds++;
			Debug.Log (seconds);
		}
		if (Time.time > nextAttack && basicNotification) {
			Debug.Log ("Attack Ready");
			basicNotification = false;
		}
		if (Time.time > nextSpecialAttack && specialNotification) {
			specialNotification = false;
			Debug.Log ("Special Attack Ready");
		}
		if (Input.GetKeyDown (KeyCode.Z) && Time.time > nextAttack) {
			nextAttack = Time.time + attackCooldown;
			_owner.stateMachine.ChangeState (_owner.listAttackStates [AttackStates.BASIC]);
			basicNotification = true;
		}
		if (Input.GetKeyDown (KeyCode.X) && Time.time > nextSpecialAttack) {
			nextSpecialAttack = Time.time + specialAttackCooldown;
			_owner.stateMachine.ChangeState (_owner.listAttackStates [AttackStates.SPECIAL]);
			specialNotification = true;
		}

	}
}
