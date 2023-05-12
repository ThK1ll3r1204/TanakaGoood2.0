using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _shootTime;
    [SerializeField] float _shootMaxTime;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] GameObject _playerBullet;
    private int lastDir;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Shooting();

    }

    private void Shooting()
    {
        _shootTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (_shootTime > _shootMaxTime)
            {
                Vector3 direction = Vector3.zero;
                if (lastDir == 1)
                    direction = Vector3.up;
                else if (lastDir == 2)
                    direction = Vector3.down;
                else if (lastDir == 3)
                    direction = Vector3.right;
                else if (lastDir == 4)
                    direction = Vector3.left;


                GameObject bullet = Instantiate(_playerBullet, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * 30f;
                _shootTime = 0;
            }
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (vertical == 1)
            lastDir = 1;
        else if (vertical == -1)
            lastDir = 2;
        else if (horizontal == 1)
            lastDir = 3;
        else if (horizontal == -1)
            lastDir = 4;

        Vector2 _move = new Vector2(horizontal * _speed, vertical * _speed);

        _rb.velocity = _move;
    }
}
