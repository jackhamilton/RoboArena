using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : MonoBehaviour {

    public static int playerSelectedArmor;
    //1: green, 2: blue
    public static int playerSelectedWeapon;
    //1: carbine, 2: luger

    public GameObject green;
    public GameObject blue;
    public GameObject carbine;
    public GameObject luger;

	// Use this for initialization
	void Start () {
        if (playerSelectedArmor == 1)
        {
            green.SetActive(true);
        } else
        {
            green.SetActive(false);
        }
        if (playerSelectedArmor == 2)
        {
            blue.SetActive(true);
        } else
        {
            blue.SetActive(false);
        }
        if (playerSelectedWeapon == 1)
        {
            carbine.SetActive(true);
        } else
        {
            carbine.SetActive(false);
        }
        if (playerSelectedWeapon == 2)
        {
            luger.SetActive(true);
        } else
        {
            luger.SetActive(false);
        }
    }

    public void savePrefs()
    {
        if (green.activeSelf)
        {
            playerSelectedArmor = 1;
        }
        if (blue.activeSelf)
        {
            playerSelectedArmor = 2;
        }
        if (carbine.activeSelf)
        {
            playerSelectedWeapon = 1;
        }
        if (luger.activeSelf)
        {
            playerSelectedWeapon = 2;
        }
    }
}
