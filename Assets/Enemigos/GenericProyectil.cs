using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericProyectil : MonoBehaviour
{
    [SerializeField] PlayerStats pStats;
    [SerializeField] float damage;
    [SerializeField] Rigidbody2D rb2d;

    private void Awake()
    {
        pStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MakeDamage();
        }
        if (!collision.CompareTag("Enemy"))
            Destroy(this.gameObject);
    }

    public void MakeDamage()
    {
        pStats._pLife -= damage;
    }
}
