using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController
{
    protected GameObject player;
    protected Rigidbody2D rb;

    protected float jumpHeight;
    protected bool isJumping;
    protected int extraJumps;
    protected int defaultExtraJumps;
    protected float doubleJumpForceMultiplier;

    protected float speed;
    protected float speedMultiPlier;

    protected LayerMask groundLayer;
    protected bool isOnGround;
    public Transform groundCheck;
    protected const float groundCheckRadius = 0.2f;

    public virtual void Updates(float jumpHeight, float speed)
    {
        this.jumpHeight = jumpHeight;
        this.speed = speed;
    }
    public virtual void FixedUpdates()
    {

        isOnGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != player.gameObject)
            {
                isOnGround = true;

                extraJumps = defaultExtraJumps;
            }
        }

        PlayerMove();
    }
    public virtual void Jump()
    {
        if (!isOnGround)
        {
            if (extraJumps > 0)
            {
                if (rb.velocity.y < 0)
                {
                    Vector3 v = rb.velocity;
                    v.y = 0.0f;
                    rb.velocity = v;

                    rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                    extraJumps--;
                }
            }
        }
        else
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }
    public virtual void PlayerMove()
    {
        rb.velocity = new Vector2(Time.deltaTime * speed * speedMultiPlier, rb.velocity.y);
    }
    public void SetSpeedMultiplier(float speedMultiPlier)
    {
        this.speedMultiPlier = speedMultiPlier;
    }






}

