using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class JumpState : IState<Player> {
	public void EnterState(Player _owner) {
		Debug.Log ("Entering Jumping State");
	}

	public void ExitState(Player _owner) {
		Debug.Log ("Exiting Jumping State");
	}

	public void UpdateState(Player _owner) {
		Debug.Log ("Jumping....");
	}

}

