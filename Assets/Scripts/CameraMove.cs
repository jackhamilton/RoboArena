using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	public GameObject LevelBounds;
	public Camera Camera;
	Vector3 targetPos;
	float interpVelocity;
	private Vector3 minb, maxb;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		minb = LevelBounds.GetComponent<BoxCollider2D>().bounds.min;
		maxb = LevelBounds.GetComponent<BoxCollider2D>().bounds.max;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;
			Vector3 targetDirection = (target.transform.position - posNoZ);
			interpVelocity = targetDirection.magnitude * 5f;
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.95f);

			var cameraHalfWidth = Camera.orthographicSize * ((float) Screen.width / Screen.height);
			float x = Mathf.Clamp(transform.position.x, minb.x + cameraHalfWidth, maxb.x - cameraHalfWidth);
			float y = Mathf.Clamp(transform.position.y, minb.y + Camera.orthographicSize, maxb.y - Camera.orthographicSize);
			transform.position = new Vector3(x, y, transform.position.z);

		}
	}
}