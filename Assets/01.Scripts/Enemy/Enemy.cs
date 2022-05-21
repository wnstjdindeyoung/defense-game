using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public void OnDamage(float damage, GameObject damageDealer)
    {
        Damaged(damage);
    }

    [SerializeField] private float Speed = 3f;
    [SerializeField] private float attackDis = 5f;
    [SerializeField] private float health;


    Vector2 dir;
    GameObject player;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    public enum State
    {
        move, 
        attack
    }

    public State state = State.move;

    private void Update()
    {
        switch(state)
        {
            case State.move:
                EnemyMove();
                break;
            case State.attack:
                Attack();
                break;
        }

        Died();
    }

    private void EnemyMove()
    {
        //이동
        Vector2 moveDir;
        dir = (player.transform.position - transform.position).normalized;
        moveDir = new Vector2(dir.x, rb.velocity.y);

        rb.velocity = moveDir * Speed;

        //state 변경
        if(Vector2.Distance(transform.position, player.transform.position) <= attackDis)
        {
            state = State.attack;
        }
    }

    private void Attack()
    {
        //공격
        

        //state 변경 
        if(Vector2.Distance(transform.position, player.transform.position) > attackDis)
        {
            state = State.move;
        }
    }

    private void Damaged(float damage)
    {
        print("hit");

        health -= damage;
        StartCoroutine(MoveSlow());
    }

    private void Died()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator MoveSlow()
    {
        Speed /= 2;
        yield return new WaitForSeconds(0.7f);
        Speed *= 2;
    }
}
