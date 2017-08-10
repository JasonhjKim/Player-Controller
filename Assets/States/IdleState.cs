using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class IdleState :IState<Player> {
	public void EnterState (Player _owner) {
		Debug.Log ("Entering Idle State");
	}

	public void ExitState (Player _owner) {
		Debug.Log ("Exiting Idle State");
	}

	public void UpdateState (Player _owner) {
		
	}
		
}
