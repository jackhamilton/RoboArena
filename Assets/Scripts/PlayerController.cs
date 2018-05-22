using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	void Start() {

		rb = GetComponent<Rigidbody2D>();
		Physics2D.IgnoreLayerCollision (8, 9);
	}

	void Update () {

		//Add player input as rigidbody forces
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector3(horizontal*100, vertical*100, 0f));

	}
}
