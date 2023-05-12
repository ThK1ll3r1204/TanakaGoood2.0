using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float boTimerMax;
    private float boTimer;

    [SerializeField] float bullTimerMax;
    private float bullTimer;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        bullTimerMax = boTimerMax * 2f;
    }

    private void Update()
    {
        boTimer += Time.deltaTime;

        if (boTimer >= boTimerMax)
        {
            StartCoroutine(Boomerang());
            bullTimer += Time.deltaTime;

            if (bullTimer >= bullTimerMax)
                Destroy(this.gameObject);
        }
    }

    IEnumerator Boomerang()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.1f);
        rb2d.constraints = RigidbodyConstraints2D.None;
        Vector3 direction = this.transform.parent.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10;
    }
}
