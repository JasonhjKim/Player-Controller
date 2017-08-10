using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff {
	public class StateMachine<T> {
		public IState<T> currentState;
		public T Owner;

		public StateMachine(T _owner) {
			Owner = _owner;
		}

		public void ChangeState(IState<T> _newState) {
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
}
