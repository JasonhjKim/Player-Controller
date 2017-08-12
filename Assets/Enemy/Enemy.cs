using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Transform target;
	public StateMachine<Enemy> stateMachine;
	public Dictionary<EnemyMovementStates, IState<Enemy>> dicEnemyMovementStates;

	//Idle variables
	public float idleTime;
	public bool isIdling;

	//Patrol variables
	public float patrolTime;
	public float patrolRange;
	public float patrolSpeed;

	//Chase variables
	public float chaseTime; //
	public float chaseRange; //Used in Raycast to detect player
	public float chaseOutofRange; //
	public float chaseSpeed; //
	public bool isChasing; //To turn off raycasting || turned back on chaseOutofRange;

	public LayerMask wallLayer;
	private RaycastHit2D hitWall;
	private float detectWall = 1f;

	public LayerMask playerLayer;
	private RaycastHit2D hitPlayer;
	private float detectPlayer = 5f;
	float deltaSize;


	protected int direction;

	public void Start() {
		Initialization ();
		deltaSize = GetComponent<BoxCollider2D> ().bounds.size.x;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		stateMachine.ChangeState (dicEnemyMovementStates [EnemyMovementStates.IDLE]);;
		isIdling = true;
		Debug.Log ("Log: " + direction);
	}

	public void Update() {
		hitWall = Physics2D.Raycast (this.transform.position, this.transform.right * direction, detectWall - deltaSize, wallLayer);
		Debug.DrawRay (this.transform.position, this.transform.right * direction * (detectWall - deltaSize), Color.red);
		if (hitWall) {
			Rotate ();
		}

		hitPlayer = Physics2D.Raycast (this.transform.position, this.transform.right * direction, detectPlayer - deltaSize, playerLayer);
		Debug.DrawRay (this.transform.position, this.transform.right * direction * (detectPlayer - deltaSize), Color.blue);
		if (hitPlayer && !isChasing) {
			isChasing = true;
			isIdling = false;
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			Rotate ();
		}
		stateMachine.Update ();
	}

	public void Rotate() {
		Vector3 changeScale = transform.localScale;
		changeScale.x *= -1;
		this.transform.localScale = changeScale;
		direction = (int)(Mathf.Sign (changeScale.x));
	}

	//Instead of returning int, simply set the value to variable
	private void Initialization() {
		stateMachine = new StateMachine<Enemy> (this);
		dicEnemyMovementStates = new Dictionary<EnemyMovementStates, IState<Enemy>> ();
		dicEnemyMovementStates.Add (EnemyMovementStates.IDLE, new IdleMovementState());
		dicEnemyMovementStates.Add (EnemyMovementStates.CHASE, new ChaseState());
		dicEnemyMovementStates.Add (EnemyMovementStates.PATROL, new PatrolState());

		int temp = Random.Range (0, 2);
		switch (temp) {
		case 0:
			direction = -1;
			Rotate ();
			break;
		case 1:
			direction = 1;
			break;
		}
	}
	public float DistanceFromTarget() {
		return Vector2.Distance (target.transform.position, transform.position);
	}

	public int DirectionFromTarget() {
		return (int) (Mathf.Sign (target.transform.position.x - transform.position.x));
	}

	public bool DirectionChecker(int check) {
		if (direction == check) {
			return true;
		}
		return false;
	}
}

public enum EnemyMovementStates {
	IDLE,
	PATROL,
	CHASE
}