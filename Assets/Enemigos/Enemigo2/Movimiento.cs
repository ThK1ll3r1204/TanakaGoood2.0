using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public float direction;
    public GameObject target;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        direction = Vector2.Distance(transform.position, target.transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
    }
} 