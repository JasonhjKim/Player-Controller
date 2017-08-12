using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager _instance;

	private GameManager() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static GameManager Instance {
		get { 
			if (_instance == null) {
				new GameManager ();
			}
			return _instance;
		}
	}

	public void PauseGame(bool paused) {
		
	}
}
