using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 2.0f;
    private float dirX;

    [SerializeField] private float jumpForce = 10.0f;
    private bool isGrounded;
    private bool isFacingRight = true;
    public bool isAttacking = false;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Update() {
        PlayerMove();
        PlayerJump();
    }

    // Update is called once per frame
    private void PlayerMove() { 
        if (isGrounded && !isAttacking) {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Input: Move Right Key");
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Input: Move Left Key");
            }

            if (dirX > 0 && !isFacingRight) {
                Flip();
            } 
            else if (dirX < 0 && isFacingRight) {
                Flip();
            }
        }
        else if (isGrounded && isAttacking) {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Debug.Log("Input: Jump");
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
    
}