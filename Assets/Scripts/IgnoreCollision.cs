using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	public Transform ignored;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (ignored.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
	}
}
