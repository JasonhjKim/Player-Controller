﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff {
	public class StateMachine<T> {
		public State<T> currentState{ get; set;}
		public T Owner;

		public StateMachine(T _owner) {
			Owner = _owner;
		}

		public void ChangeState(State<T> _newState) {
			if (currentState != null)
				currentState.ExitState(Owner);
			currentState = _newState;
			currentState.EnterState (Owner);
		}
		public void Update () {
			if (currentState != null) {
				currentState.UpdateState (Owner);
			}
		}
	}

	public abstract class State<T> {
		public abstract void EnterState (T _owner);
		public abstract void ExitState (T _owner);
		public abstract void UpdateState(T _owner);
	}
}
