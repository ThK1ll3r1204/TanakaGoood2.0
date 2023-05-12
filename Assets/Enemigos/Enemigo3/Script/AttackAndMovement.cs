using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAndMovement : MonoBehaviour
{
    [SerializeField] public EnemyDetect detect;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject bulletEnemy3;
    [SerializeField] public float moveSpeed;


    [SerializeField] float _bSpeed;
    [SerializeField] float _bCooldown;
    private float _bCooldowntimer;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        detect = GetComponent<EnemyDetect>();
    }

    void Update()
    {
        Movement();

        if (detect.playerDetected && _bCooldowntimer <= 0)
        {
            ShootThePlayer();
        }

    }

    private void Movement()
    {
        if (detect.playerDetected && detect.distanceToPlayer > 7f)
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Vector3 direction = player.transform.position - transform.position;
            this.GetComponent<Rigidbody2D>().velocity = direction.normalized * moveSpeed;
        }
        else if (detect.playerDetected && detect.distanceToPlayer < 5f)
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Vector3 direction = transform.position - player.transform.position;
            this.GetComponent<Rigidbody2D>().velocity = direction.normalized * moveSpeed * 1.5f;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void FixedUpdate()
    {
        //Cooldown del disparo
        if (_bCooldowntimer > 0f)
        {
            _bCooldowntimer -= Time.deltaTime;
        }
    }

    void ShootThePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletEnemy3, transform.position, Quaternion.identity, this.transform);
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * _bSpeed;
        _bCooldowntimer = _bCooldown;
    } 
}
