using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class FallState: IState<Player> {
		
	public void EnterState(Player _owner) {
		Debug.Log ("Entering Falling State");
	}

	public void ExitState(Player _owner) {
		Debug.Log ("Exiting Falling State");
	}

	public void UpdateState(Player _owner) {
		
	}
}
