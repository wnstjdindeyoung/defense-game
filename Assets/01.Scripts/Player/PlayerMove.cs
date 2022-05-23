using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpPower = 5f;
    [SerializeField] private Transform footPos;
    private bool isGround = false;
    private float radios = 0.3f;
    public LayerMask groundLayer;
    public float moveDirValue;

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

        /*Vector2 look = transform.localScale;
        Vector2 leftLook = new Vector2(-1.5f, 1.5f);
        Vector2 rightLook = new Vector2(1.5f, 1.5f);*/

        if (moveDirValue == 1) { transform.localRotation = Quaternion.Euler(0, 0, 0); }
        else if (moveDirValue == -1) { transform.localRotation = Quaternion.Euler(0, 180, 0); }
        //transform.localScale = look;
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
