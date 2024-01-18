using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 2.0f;
    private float dirX;

    [SerializeField] private float jumpForce = 10.0f;
    private bool isGrounded;
    private bool isFacingRight = true;
    public bool canMove = true;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Update() {
        PlayerMove();
        PlayerJump();
    }

    // Update is called once per frame
    void PlayerMove() { 
        if (isGrounded && canMove) {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (dirX > 0 && !isFacingRight) {
                Flip();
            } 
            else if (dirX < 0 && isFacingRight) {
                Flip();
            }
        }
    }

    void PlayerJump() {

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Flip() {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
    
}