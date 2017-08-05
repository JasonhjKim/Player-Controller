using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineStuff;

public class StateTemp : State<PSM> {
	public static StateTemp _instance;
	private StateTemp() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static StateTemp Instance {
		get { 
			if (_instance == null) {
				new StateTemp ();
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
