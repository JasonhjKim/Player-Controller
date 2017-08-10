using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T> {
	void EnterState(T _owner);
	void ExitState(T _owner);
	void UpdateState(T _owner);
}
