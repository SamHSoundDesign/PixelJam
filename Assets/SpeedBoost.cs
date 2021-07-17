using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private GameController gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NotHero"))
        {
            gameController.NotHeroBoost();
            Destroy(gameObject);
        }
    }

    public void SetUp(GameController gameController)
    {
        this.gameController = gameController;

    }
}
