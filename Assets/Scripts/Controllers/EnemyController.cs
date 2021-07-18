using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{

    private List<Enemy> enemyList;
    public EnemyController(EnemyData[] enemyArray)
    {
        enemyList = new List<Enemy>();
        foreach (EnemyData enemyData in enemyArray)
        {
            Enemy tempEnemy = new Enemy(enemyData.gameObject);
            enemyData.SetUpEnemyData(tempEnemy);
            enemyList.Add(tempEnemy);
        }

    }
}
