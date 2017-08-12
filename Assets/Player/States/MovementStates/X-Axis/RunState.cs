using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : IState<PlayerXMovement> {
	public void EnterState(PlayerXMovement _owner) {
	}

	public void ExitState(PlayerXMovement _owner) {
	}

	public void UpdateState(PlayerXMovement _owner) {
		Debug.Log ("Running...");
	}

}
