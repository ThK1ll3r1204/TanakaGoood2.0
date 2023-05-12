using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public float timer;
    public float maxTimer;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                GameObject obj = Instantiate(bullet);
                obj.transform.position = transform.position;
                Vector2 direction = target.position - transform.position;
                obj.GetComponent<BulletE2>().direction = direction.normalized;
                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
