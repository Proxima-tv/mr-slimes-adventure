using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 11f;
    public float JumpForce = 5f;

    [Header("Grounded Checks")]
    public Transform groundCheck;
    public bool isGrounded = true;
    public LayerMask ground;
    public bool JumpBoost = false;
    public int jumps = 0;

    public SoundManager soundManager;

    [Header("Physics")]
    Rigidbody2D rb;
    BoxCollider2D box;
    private bool isRedundandGrounded;
    private InputMapper inputMapper;

    // Start is called before the first frame update
    void Start()
    {
        inputMapper = GetComponent<InputMapper>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Jump")
        {
            JumpBoost = true;
            jumps = 3;
        }
    }

    private void Update()
    {
        // catch input and jump when grounded
        if (inputMapper.Jump && isGrounded || inputMapper.Jump && isRedundandGrounded) {
            // Play Jump Sounds
            soundManager.playOnPlayer("Jump", 0);
            if (JumpBoost) {
                rb.AddForce(Vector2.up * (JumpForce + 20), ForceMode2D.Impulse);

                if (jumps >= 1) {
                    jumps--;
                } else {
                    JumpBoost = false;
                }
            } else {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // this is just here in order to prevent jump lockdowns means player can stop jumping out of nowhere
        // basicly this line is here to do redundand jump checks
        isRedundandGrounded = Physics2D.OverlapPoint(groundCheck.position, ground);

        // Catches Input and applies input based on integer value from (-1 to 1) * Jumpforce
        Vector3 move = new Vector3(inputMapper.Horizontal * speed, rb.velocity.y, 0f);
        rb.velocity = move;
    }

    /**
     * Collision Based Jumping
     * by Catching all Collision events we check if the player is grounded
     * a possible bug may but has not yet occured where unintended walljumps might happen
     * 
     * the system detects a gameobjects tag to verify it as ground
     * 
     * it checks on enter and stay if the collision with the ground occurs
     * on Exit the system isnt grounded anymore and falses out of isgrounded
     */
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.tag == "Ground");
        if (collision.gameObject.layer == ground)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
