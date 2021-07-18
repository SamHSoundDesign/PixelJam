using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : PlayerController
{
    private List<float> notHeroJumpPosX;
    private bool queuedJumps;


    public HeroController(GameObject hero)
    {
        this.player = hero;
        rb = hero.GetComponent<Rigidbody2D>();
        groundCheck = hero.transform.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");
        isJumping = false;
        extraJumps = 1;
        defaultExtraJumps = extraJumps;
        
        speedMultiPlier = 1f;

        notHeroJumpPosX = new List<float>();
        queuedJumps = false;
    }

    public override void Updates(float jumpHeight, float speed)
    {
        base.Updates(jumpHeight, speed);
    }
    public override void FixedUpdates()
    {
        base.FixedUpdates();

        if(queuedJumps)
        {
            if (player.transform.position.x >= notHeroJumpPosX[0])
            {
                Jump();
                notHeroJumpPosX.RemoveAt(0);

                if (notHeroJumpPosX.Count == 0)
                {
                    queuedJumps = false;
                }
            }
        }

        

        base.FixedUpdates();
    }

    public override void PlayerScroll()
    {
        base.PlayerScroll();
    }

    public override void Jump()
    {
        base.Jump();
        
    }

    public void HeroJump(float notHeroJumpPosX)
    {
        this.notHeroJumpPosX.Add(notHeroJumpPosX);
        if(!queuedJumps)
        {
            queuedJumps = true;
        }
    }






}
