using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public float health = 100;
    public GameObject gameOverPanel;
    public bool isPlayer = false;
    private float maxhealth;
    private float initialBarScale = 0;

    void Start()
    {
        maxhealth = health;
        if (transform.GetChild(0) != null)
        {
            GameObject hbarback = transform.GetChild(0).gameObject;
            if (hbarback.transform.GetChild(0) != null)
            {
                GameObject health = hbarback.transform.GetChild(0).gameObject;
                initialBarScale = health.transform.localScale.x;
            }
        }
    }

    void Update()
    {
        if (transform.GetChild(0) != null)
        {
            GameObject hbarback = transform.GetChild(0).gameObject;
            if (hbarback.transform.GetChild(0) != null)
            {
                GameObject healthBar = hbarback.transform.GetChild(0).gameObject;
                healthBar.transform.localScale = new Vector3(initialBarScale * (health / maxhealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            }
        }
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            if (!isPlayer)
            {
                ((Text)gameOverPanel.transform.GetChild(0).gameObject.GetComponent<Text>()).text = "You Win!";
            }
            Time.timeScale = 0;
        }
    }

}
