using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private float damage = 1;

    private Transform handTrm;
    private Transform firePos;

    Rigidbody2D rb;

    public float SetDamage(float value)
    {
        damage = value;
        return damage;
    }
    public Transform SetFirePos(Transform value)
    {
        firePos = value;
        return firePos;
    }

    public override void Reset()
    {
        transform.rotation = handTrm.rotation;
        //transform.position = firePos.position;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        handTrm = GameObject.Find("Hand").GetComponent<Transform>();
        //firePos = GameObject.Find("FirePosition").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        StartCoroutine(PoolPush());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D col;
         
        if (collision.gameObject.CompareTag("Enemy"))
        {
            col = collision;
            IDamageable iDmg = col.GetComponent<IDamageable>();
            iDmg.OnDamage(damage);
        }

        if(collision.gameObject.name != "Player")
            PoolManager.instance.Push(this);
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    IEnumerator PoolPush()
    {
        if(gameObject.activeSelf == true) 
        {
            yield return new WaitForSeconds(lifeTime);
            PoolManager.instance.Push(this);
        }
    }
}
