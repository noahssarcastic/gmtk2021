using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;
    
    [SerializeField] [Range(0, 1)] private float airSpeedModifier = 1f;

    [SerializeField] private LayerMask isGround;
    [SerializeField] private float groundCheckDepth = 0.1f;

    [SerializeField] private float jumpMultiplier = 10f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    private float defaultGravity;
    private bool isGrounded;
    
    private Vector2 movement;
    private bool isMoving;

    private bool facingRight = true;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = transform.GetComponent<BoxCollider2D>();
        defaultGravity = playerRigidbody.gravityScale;
    }

    void Update() {
        // Update ground check
        isGrounded = playerIsGrounded();

        // Get horizontal movement
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);
        isMoving = input.x != 0f;
        movement = input;

        // If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
        
        // Add jump force
        if (Input.GetButtonDown("Jump") && isGrounded) {
            playerRigidbody.AddForce(Vector2.up * jumpMultiplier);
        }

        // Change gravity curve
        float playerYVelocity = playerRigidbody.velocity.y;
        bool isPressingJump = Input.GetButton("Jump");
        if (!isGrounded && playerYVelocity < 0) {
            playerRigidbody.gravityScale = defaultGravity * fallMultiplier;
        } else if (!isGrounded && playerYVelocity > 0 && !isPressingJump) {
            playerRigidbody.gravityScale = defaultGravity * lowJumpMultiplier;
        } else {
            playerRigidbody.gravityScale = defaultGravity;
        }
    }

    void FixedUpdate() {
        if (isMoving) {
            Vector2 velocity = movement * playerSpeed;
            if (!isGrounded) {
                // Reduce control in air
                velocity *= airSpeedModifier;
            } 
            playerRigidbody.AddForce(velocity);
        } else if (isGrounded) {
            // Reset horizontal velocity
            playerRigidbody.velocity *= new Vector2(0, 1);
        }
    }

    private bool playerIsGrounded() {
        Vector2 playerCenter = playerCollider.bounds.center;
        float playerHeight = playerCollider.bounds.size.y;
        float centerToCenter = (playerHeight / 2) + (groundCheckDepth / 2);
        Vector2 groundCheckOffset = Vector2.down * centerToCenter;
        Vector2 groundCheckCenter = playerCenter + groundCheckOffset;
        Vector2 groundCheckSize = new Vector2(playerHeight, groundCheckDepth);
        Collider2D hit = Physics2D. OverlapBox(
            groundCheckCenter, 
            groundCheckSize, 
            0f, 
            isGround);
        return hit != null; 
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
