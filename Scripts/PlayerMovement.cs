using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField]private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 10f;
    [SerializeField] private AudioSource jumpAudio;
    private enum MovementState { idle, running, jumping, falling }
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        coll=GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(dirX*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpAudio.Play();
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
        }
        UpdateAnimationState();
        
    }
    private void UpdateAnimationState()
    {
        MovementState State;
        if (dirX > 0f)
        {
            State=MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            State=MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            State=MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }

        anim.SetInteger("State",(int)State);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
