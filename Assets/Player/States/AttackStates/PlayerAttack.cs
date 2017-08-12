using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public StateMachine<PlayerAttack> stateMachine;
	public Dictionary<AttackStates, IState<PlayerAttack>> listAttackStates;
	// Use this for initialization
	void Start () {
		InitializeAllStates ();
		stateMachine.ChangeState (listAttackStates [AttackStates.IDLE]);
	}
	
	// Update is called once per frame
	void Update () {
		stateMachine.Update ();
	}

	private void InitializeAllStates() {
		stateMachine = new StateMachine<PlayerAttack> (this);
		listAttackStates = new Dictionary<AttackStates, IState<PlayerAttack>> ();

		listAttackStates.Add (AttackStates.BASIC, new BasicAttackState ());
		listAttackStates.Add (AttackStates.SPECIAL, new SpecialAttackState ());
		listAttackStates.Add (AttackStates.IDLE, new IdleAttackState ());
	}
}

public enum AttackStates {
	IDLE,
	BASIC,
	SPECIAL
}
