using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField] private LayerMask groundLayer;
    private float dirX = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private enum State { idle, Running, Jumping, Falling }
    
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        State state;
        if(dirX > 0f)
        {
            state = State.Running;
            sr.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = State.Running;
            sr.flipX = true;
        }
        else
        {
            state = State.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = State.Jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = State.Falling;
        }

    anim.SetInteger("state", (int)state);
    
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

}
