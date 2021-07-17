using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillZone : MonoBehaviour
{
    private AstroidShower astroidShower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(astroidShower == null)
        {
            astroidShower = GetComponentInParent<AstroidShower>();
        }

        astroidShower.assetPool.ReturnToAssetPool(ObjectTypes.Asteroid, collision.gameObject);
    }
}
