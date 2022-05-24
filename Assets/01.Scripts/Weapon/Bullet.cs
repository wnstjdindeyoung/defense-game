using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D col;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            col = collision;
            IDamageable iDmg = col.GetComponent<IDamageable>();
            iDmg.OnDamage(1);
        }

        Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
