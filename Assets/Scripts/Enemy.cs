using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy
{
    private GameObject enemy;
    private int health;
    

    public Enemy(GameObject enemy )
    {
        health = 100;
        this.enemy = enemy;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log(health);

        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            Death();
            Debug.Log("Enemy dead");
        }
        else
        {
            Debug.Log("Enemy Hit - current enemy health = " + health);
        }

    }

    private void Death()
    {
        enemy.GetComponent<EnemyData>().Destroy();
       
    }
}
