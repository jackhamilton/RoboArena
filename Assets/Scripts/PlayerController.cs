using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
	private Rigidbody2D rb;
    public GameObject green;
    public GameObject blue;
    public GameObject carbine;
    public GameObject luger;

	void Start() {

		rb = GetComponent<Rigidbody2D>();
		Physics2D.IgnoreLayerCollision (8, 9);

        if(Workshop.playerSelectedArmor == 1)
        {
            green.SetActive(true);
        } else
        {
            green.SetActive(false);
        }
        if (Workshop.playerSelectedArmor == 2)
        {
            blue.SetActive(true);
        }
        else
        {
            blue.SetActive(false);
        }
        if (Workshop.playerSelectedWeapon == 1)
        {
            carbine.SetActive(true);
        }
        else
        {
            carbine.SetActive(false);
        }
        if (Workshop.playerSelectedWeapon == 2)
        {
            luger.SetActive(true);
        }
        else
        {
            luger.SetActive(false);
        }
    }

	void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();
		//Add player input as rigidbody forces
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector3(horizontal*100, vertical*100, 0f));
		transform.eulerAngles = Vector3.zero;

	}
}
