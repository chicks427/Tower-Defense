using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Transform target;
	public float range = 10;
	public string enemyTag = "Enemy";
    public Transform rotationPivot;
    public float turnSpeed = 8;
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
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        	return;

        // Target lock-on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPivot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, range);
    }
}
