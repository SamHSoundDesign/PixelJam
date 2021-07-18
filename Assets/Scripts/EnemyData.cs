using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private Enemy enemy;
    
    public void TakeDamage(int damage)
    {
        Debug.Log("h");
        enemy.TakeDamage(damage);
    }

    public void SetUpEnemyData(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
