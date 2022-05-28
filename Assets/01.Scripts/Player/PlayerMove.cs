using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpPower = 5f;
    [SerializeField] private Transform footPos;
    [SerializeField] private LayerMask groundLayer;

    private bool isGround = false;
    private float radios = 0.3f;
    
    public bool lookLeft = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveDirValue = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirValue * MoveSpeed, rb.velocity.y);
        
        //방향 전환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = transform.position - mousePos;

        if (lookDir.x < 0) 
        { 
            transform.localRotation = Quaternion.Euler(0, 0, 0); 
            lookLeft = false;
        }
        else if (lookDir.x > 0) 
        { 
            transform.localRotation = Quaternion.Euler(0, 180, 0); 
            lookLeft = true;
        }
    }

    private void Jump()
    {
        isGround = CheckGround();

        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    private bool CheckGround()
    {
        Collider2D col = Physics2D.OverlapCircle(footPos.position, radios, groundLayer);

        return col;
    }
}
