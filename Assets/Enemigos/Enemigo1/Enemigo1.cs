using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float bulletSpeed;
    public float moveTimer;
    public float moveMaxTimer;
    public float shootTimer;
    public float shootMaxTimer;
    public GameObject enemyBullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        Vector2 move = new Vector2(transform.position.x * speed, 0).normalized;


        rb.velocity = move;


        moveTimer += Time.deltaTime;

        shootTimer += Time.deltaTime;


        if (moveTimer >= moveMaxTimer)

        {
            speed *= -1;
            moveTimer = 0;

        }

        if (shootTimer >= shootMaxTimer)
        {
            Vector3 direction = move;
            GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
            shootTimer = 0;

        }
    }
}
