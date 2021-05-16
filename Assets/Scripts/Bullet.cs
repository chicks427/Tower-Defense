using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;

	public float speed = 30;
	public GameObject bulletImpactEffect;

    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
        	Destroy(gameObject);
        	return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
        	HitTarget();
        	return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
    	GameObject effectIns = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
    	Destroy(effectIns, 2f);

    	Destroy(gameObject);
    	Destroy(target.gameObject);
    }
}
