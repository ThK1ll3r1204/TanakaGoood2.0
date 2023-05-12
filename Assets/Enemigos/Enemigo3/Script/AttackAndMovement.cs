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
        if (detect.playerDetected && detect.distanceToPlayer > 5f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else if (detect.distanceToPlayer < 5f)
        {

        }

        if (detect.playerDetected && _bCooldowntimer <= 0)
        {
            ShootThePlayer();
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
