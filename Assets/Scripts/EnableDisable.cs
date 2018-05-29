using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour {

    public void disable()
    {
        this.transform.gameObject.SetActive(false);
    }

    public void enable()
    {
        this.transform.gameObject.SetActive(true);
    }

}
