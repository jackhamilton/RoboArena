using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float followDistance;
	public float moveAwayDistance;

	private Queue reactionQueue = new Queue ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		reactionQueue.Enqueue (target.transform.position);
		if (reactionQueue.Count > 30) {
			Vector3 pos = (Vector3)reactionQueue.Dequeue();
			float step = speed * Time.deltaTime;
			float distance = Vector3.Distance (transform.position, pos);
			if (distance > followDistance) {
				transform.position = Vector3.MoveTowards (transform.position, pos, step);
			} else { //if (distance < moveAwayDistance) {
				//transform.position = Vector3.MoveTowards (transform.position, pos, -1*step);
				//Maybe move diagonally away
				Vector3 direction = pos - transform.position;
				Vector3 moveAlong = new Vector3 (direction.y, direction.x * -1, 0f).normalized * step;
				transform.position += moveAlong;
			}
		}
	}
}
