using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class WalkState : IState<Player> {
	public void EnterState(Player _owner) {
		Debug.Log ("Entering Walking State");
	}

	public void ExitState(Player _owner) {
		Debug.Log ("Exiting Walking State");
	}

	public void UpdateState(Player _owner) {
		Debug.Log ("Walking..");
	}

}
