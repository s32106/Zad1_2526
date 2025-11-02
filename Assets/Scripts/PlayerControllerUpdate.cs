using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 7;
    public float jumpForce = 100;
    private float moveInput = 0;

    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private bool isSprint = false;
    private float moveVector = 0;
    private bool isJump = false;

    public GroundChecker groundChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y);

        moveVector = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            isJump = true;
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
    }
}