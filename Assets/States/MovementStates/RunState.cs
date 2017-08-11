using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : IState<PlayerMovement> {
	public void EnterState(PlayerMovement _owner) {
	}

	public void ExitState(PlayerMovement _owner) {
	}

	public void UpdateState(PlayerMovement _owner) {
		Debug.Log ("Running...");
	}

}
