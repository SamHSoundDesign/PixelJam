using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotHeroController : PlayerController
{
    private HeroController heroController;

    private float boostDelay;
    private float boostStartTimer;
    private float boostMultiplier;

   

    public NotHeroController(GameObject notHero , HeroController heroController , GameObject bullet , Transform bulletsParent) 
    {
        this.player = notHero;
        
        this.bullet = bullet;
        this.gun = player.GetComponentInChildren<Gun>();
        this.bulletsParent = bulletsParent;

        rb = notHero.GetComponent<Rigidbody2D>();
        groundCheck = notHero.transform.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");
        isJumping = false;
        extraJumps = 1;
        defaultExtraJumps = extraJumps;
        speedMultiPlier = 1f;

        this.heroController = heroController;

        boostDelay = 1f;
        boostStartTimer = 0f;
        boostMultiplier = 1.5f;

       
    }
    

    public override void Updates(float jumpHeight, float speed)
    {
        gun.FixedUpdates();

        if (Time.time <= boostStartTimer)
        {
            base.Updates(jumpHeight, speed * boostMultiplier);
        }
        else
        {
            base.Updates(jumpHeight, speed);
        }
    }
    public override void FixedUpdates()
    {
        base.FixedUpdates();
    }

    public override void PlayerScroll()
    {
        base.PlayerScroll();
    }

    public override void Jump()
    {
        base.Jump();
        heroController.HeroJump(player.transform.position.x);
    }

    public void Boost()
    {
        boostStartTimer = Time.time + boostDelay;
        rb.AddForce(new Vector2(0f, 3f) , ForceMode2D.Impulse);
        Debug.Log("DONEIT");
    }


}

