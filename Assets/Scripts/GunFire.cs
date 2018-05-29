using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float reloadTimeSeconds;
    private float cReloadTimeSeconds;
    public float damage;
    public GameObject particleSystemPrefab;
    public GameObject bulletTrailPrefab;
    public LayerMask layersToHit;
    public float degreeHitVariation = 30;
    public float lockDistance = 10;
    private float lastFireTime = 0;
    private LineRenderer renderTrail = null;

    // Use this for initialization
    void Start () {
        cReloadTimeSeconds = reloadTimeSeconds + Random.Range(-0.2f, 0.2f) * reloadTimeSeconds;
    }
	
	// Update is called once per frame
	void Update ()
    {
        LookAt weapon = GetComponent<LookAt>();
        float distance = Vector3.Distance(this.transform.position, weapon.Target.position);
        if (distance < weapon.lockDistance)
        {
            if (Time.time > lastFireTime + cReloadTimeSeconds)
            {
                Vector2 source = Vector2.zero;
                if (Workshop.playerSelectedWeapon == 1) //carbine
                {
                    source = transform.position - (transform.up.normalized * 25f);
                } else
                {
                    source = transform.position - (transform.up.normalized * 18f);
                }
                Vector2 randomDirection = Quaternion.Euler(0, 0, Random.Range(-1 * degreeHitVariation, degreeHitVariation)) * -transform.up;
                RaycastHit2D hit = Physics2D.Raycast(source, randomDirection, Mathf.Infinity, layersToHit);
                if (hit.transform.gameObject.name.Contains("Player")
                    || hit.transform.gameObject.name.Contains("Enemy"))
                {
                    Stats stat = hit.transform.gameObject.GetComponent<Stats>();
                    if (stat.health - damage > 0)
                    {
                        stat.health -= damage;
                    } else
                    {
                        stat.health = 0;
                    }
                }
                GameObject particleprefab = Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
                GameObject lineprefab = Instantiate(bulletTrailPrefab);
                lineprefab.transform.position = Vector2.zero;
                renderTrail = lineprefab.GetComponent<LineRenderer>();
                renderTrail.useWorldSpace = true;
                renderTrail.SetPositions(new Vector3[] { source, hit.point });
                lastFireTime = Time.time;
                cReloadTimeSeconds = reloadTimeSeconds + Random.Range(-0.2f, 0.2f) * reloadTimeSeconds;
                Destroy(particleprefab, cReloadTimeSeconds);
                Destroy(lineprefab, cReloadTimeSeconds);
            }
            if (renderTrail != null)
            {
                if (Workshop.playerSelectedWeapon == 1) //carbine
                {
                    float fadeoutspeed = 1.5f;
                    float alpha = Mathf.Max(1 - (((Time.time - lastFireTime) / reloadTimeSeconds)) * fadeoutspeed, 0);
                    renderTrail.startColor = new Color(1, 0, 0, alpha / 2);
                    renderTrail.endColor = new Color(1, 0, 0, alpha);
                } else
                {
                    float fadeoutspeed = 2;
                    float alpha = Mathf.Max(1 - (((Time.time - lastFireTime) / reloadTimeSeconds)) * fadeoutspeed, 0);
                    renderTrail.startColor = new Color(1, 0.2392f, 0, alpha);
                    renderTrail.endColor = new Color(1, 0.2392f, 0, alpha);
                }
            }
        }
	}
}
