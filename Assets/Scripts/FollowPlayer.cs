using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float followDistance;
	public float moveAwayDistance;
	public int reactionTimeFrames;
	private Rigidbody2D rb;
	private int rotationDirection = -1;

	private Queue reactionQueue = new Queue ();
	private Queue stopDetectQueue = new Queue ();

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Physics2D.IgnoreLayerCollision (8, 9);
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = Vector3.zero;
		//Delay of 30 frames before it starts following the player, creates some reaction time for the follow bot
		reactionQueue.Enqueue (target.transform.position);
		if (reactionQueue.Count > reactionTimeFrames) {
			//Swap rotation directions if it isn't moving
			if (stopDetectQueue.Count >= 3 ) {
				Vector3 position = (Vector3)stopDetectQueue.Dequeue ();
				if ((int)Random.Range(1, 500) == 1
					|| (Mathf.Abs(position.y - transform.position.y) < 0.01
					&& Mathf.Abs(position.x - transform.position.x) < 0.01)) {
					rotationDirection *= -1;
				}
			}
			//Add the current position
			stopDetectQueue.Enqueue( transform.position);

			//Move
			Vector3 pos = (Vector3)reactionQueue.Dequeue();
			float distance = Vector3.Distance (transform.position, pos);
			//Towards the enemy bot
			Vector3 direction = pos - transform.position;
			if (distance > followDistance) {
				rb.AddForce (direction.normalized * speed * 20);
			} else { //if (distance < moveAwayDistance) {
				//transform.position = Vector3.MoveTowards (transform.position, pos, -1*step);
				//Move perpendicularly away
				Vector3 moveAlong = Vector3.zero;
				if (rotationDirection == -1) {
					moveAlong = new Vector3 (direction.y, direction.x * -1, 0f).normalized;
				} else if (distance < moveAwayDistance) {
					//perp vector plus away vector * 2
					moveAlong = new Vector3 (direction.y * -1, direction.x, 0f).normalized;
					Vector3 away = direction.normalized * -1;
					moveAlong = (moveAlong + 2 * away).normalized;
				} else {
					//perp vector
					moveAlong = new Vector3 (direction.y * -1, direction.x, 0f).normalized;
				}
				rb.AddForce (moveAlong * speed * 20);
				//transform.position += moveAlong;
			}
		}
	}
}
