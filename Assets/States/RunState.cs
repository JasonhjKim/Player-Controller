using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class RunState : IState<Player> {

	public void EnterState(Player _owner) {
		Debug.Log ("Entering Running State");
	}

	public void ExitState(Player _owner) {
		Debug.Log ("Exiting Running State");
	}

	public void UpdateState(Player _owner) {
		Debug.Log ("Running...");
	}

}
