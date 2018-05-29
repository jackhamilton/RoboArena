using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	//values that will be set in the Inspector
	public Transform Target;
	public float lockDistance;
    public bool followInput = false;
    public float trackSpeed = 10;
    //public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Target.position);
        if (distance < lockDistance) {
            Vector3 vectorToTarget = Target.transform.position - transform.position;
            vectorToTarget = new Vector3(vectorToTarget.y * -1, vectorToTarget.x, vectorToTarget.z);
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * trackSpeed);
        } else if (followInput) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 dir = new Vector2(horizontal, vertical);
            if (dir.magnitude > 0)
            {
                Vector2 perp = new Vector2(dir.y * -1, dir.x);
                Vector3 vectorToTarget = new Vector3(perp.x, perp.y, 0);
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * trackSpeed);
            }
        }
	}
}
