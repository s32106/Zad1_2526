using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    public float moveSpeed = 20;
    public float runSpeed = 7;
    public float jumpForce = 100;
    private bool isSprint = false;
    private bool isJump = false;
    private float moveVector = 0;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //moveInput = Input.GetAxis("Horizontal");
        moveVector = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }
        else
        {
            isSprint = false;
        }

        if (moveVector < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        if (isSprint)
        {
            rb.velocity = new Vector2(moveVector * runSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveVector * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }
        else
        {
            isJump = false;
        }
    }
}