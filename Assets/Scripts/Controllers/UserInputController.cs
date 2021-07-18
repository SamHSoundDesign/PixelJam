using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController
{
    private NotHeroController playerController;
    private GameController gameController;
    private bool jump;
    private bool ufoBoost;

    public UserInputController(NotHeroController playerController , GameController gameController)
    {

        this.playerController = playerController;
        this.gameController = gameController;
        jump = false;
        ufoBoost = true;
    }
   
    public void Updates(float speedMultiplier , RewindController rewindController , bool inUFO)
    {
       if(inUFO)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                playerController.FireBullet();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                ufoBoost = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerController.SetSpeedMultiplier(speedMultiplier);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerController.SetSpeedMultiplier(1f);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            rewindController.SetRewinding(true);
        }
    }

    public void FixedUpdates()
    {
        if(jump)
        {
            playerController.Jump();
            jump = false;
        }

        if(ufoBoost)
        {
            playerController.UFOboost();
            ufoBoost = false;
        }
    }
}
