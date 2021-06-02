using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
	public float range = 10;
    public float turnSpeed = 8;

    [Header("Use bullets (default")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform target;
    public Transform rotationPivot;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
    	GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    	float shortestDistance = Mathf.Infinity;
    	GameObject nearestEnemy = null;

    	foreach(GameObject enemy in enemies)
    	{
    		float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    		if (distanceToEnemy < shortestDistance)
    		{
    			shortestDistance = distanceToEnemy;
    			nearestEnemy = enemy;
    		}
    	}

    	if (nearestEnemy != null && shortestDistance <= range)
    	{
    		target = nearestEnemy.transform;
    	}
        else
        {
            target = null;
        }
    }
    void Update()
    {
        if(target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
        	return;
        }

        TargetLockOn();

        if(useLaser)
        {
            Laser();
        } 
        else
        {
            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        if(!lineRenderer.enabled)
        {
            impactEffect.Play();
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        impactEffect.transform.position = target.position;
    }

    void TargetLockOn()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPivot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, range);
    }
}
