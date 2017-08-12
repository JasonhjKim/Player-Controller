using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]

public class EnemyController : MonoBehaviour {
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;
	public LayerMask collisonMask;

	float horizontalRaySpacing;
	float verticalRaySpacing;

	BoxCollider2D collider;
	RaycastOrigins raycastOrigins;
	const float skinWidth = 0.0015f;
	public CollideInfo collisions;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		CalculateRaySpacing ();

	}

	void Update() {
	}

	public void Move(Vector3 velocity) {
		UpdateRaycastOrigins ();
		collisions.reset ();
		if (velocity.x != 0) {
			HorizontalCollisons (ref velocity);
		}

		if (velocity.y != 0) {
			VerticalCollisons (ref velocity);	
		}
		transform.Translate (velocity);
	}

	void HorizontalCollisons (ref Vector3 velocity) {
		float directionX = Mathf.Sign (velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;
		for (int i = 0; i < horizontalRayCount; i++) {
			Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.right * directionX, rayLength, collisonMask); 
			Debug.DrawRay (rayOrigin, Vector2.right * directionX * rayLength, Color.cyan);

			if (hit) {
				velocity.x = (hit.distance - skinWidth) * directionX;
				rayLength = hit.distance;

				collisions.left = directionX == -1;
				collisions.right = directionX == 1;
			}
		}
	}

	void VerticalCollisons (ref Vector3 velocity) {
		float directionY = Mathf.Sign (velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth;
		for (int i = 0; i < verticalRayCount; i++) {
			Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.up * directionY, rayLength, collisonMask); 
			Debug.DrawRay (rayOrigin, Vector2.up * directionY * rayLength, Color.red);

			if (hit) {
				velocity.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;
				collisions.below = directionY == -1;
				collisions.above = directionY == 1;
			}
		}
	}

	void UpdateRaycastOrigins() {
		Bounds bound = collider.bounds;
		bound.Expand (skinWidth * -2);
		raycastOrigins.topLeft = new Vector2(bound.min.x, bound.max.y);
		raycastOrigins.topRight = new Vector2(bound.max.x, bound.max.y);
		raycastOrigins.bottomLeft = new Vector2(bound.min.x, bound.min.y);
		raycastOrigins.bottomRight = new Vector2(bound.max.x, bound.min.y);


	}

	void CalculateRaySpacing() {
		Bounds bound = collider.bounds;
		bound.Expand (skinWidth * -2);

		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);

		horizontalRaySpacing = bound.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bound.size.x / (verticalRayCount - 1);

	}

	struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

	public struct CollideInfo {
		public bool above, below;
		public bool left, right;

		public void reset() {
			above = below = false;
			left = right = false;
		}
	}
}
