using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 1f;

	private Transform target;
	private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
        	GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
    	if (waypointIndex >= Waypoints.points.Length - 1)
    	{
    		EndPath();
    	}
    	else
    	{
    		waypointIndex++;
    		target = Waypoints.points[waypointIndex];
    	}
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
