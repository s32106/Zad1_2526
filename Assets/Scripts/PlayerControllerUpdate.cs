using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    public float moveSpeed = 20;
    public float jumpForce = 100;
    private float moveInput = 0;
    public bool isJump = false;
    public float speed = 3;
    public float doublejump = 2;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = true;
        }

    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (isJump && groundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
        }
        else
        {
            speed = 3;
        }

    }

}