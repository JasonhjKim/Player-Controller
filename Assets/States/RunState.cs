using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class RunState : State<PSM> {
	public static RunState _instance;
	private RunState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static RunState Instance {
		get { 
			if (_instance == null) {
				new RunState ();
			}
			return _instance;
		}
	}

	public override void EnterState(PSM _owner) {

	}

	public override void ExitState(PSM _owner) {

	}

	public override void UpdateState(PSM _owner) {

	}

}
