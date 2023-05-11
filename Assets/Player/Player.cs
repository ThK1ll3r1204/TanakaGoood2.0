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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector2 _move = new Vector2(horizontal * _speed, vertical * _speed);

        _rb.velocity = _move;
        _shootTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (_shootTime > _shootMaxTime)
            {
                Vector3 direction = _move;
                GameObject bullet = Instantiate(_playerBullet, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * 30f;
                _shootTime = 0;
            }
        }
        
        
    }
}
