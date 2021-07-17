using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidShower : MonoBehaviour
{
    [SerializeField] private GameObject asteroidKillZone;
    [SerializeField] private DropPoints dropPoints;
    public AssetPool assetPool;

    private bool isActive = false;

    public void ActivateAsteroidShower()
    {
        foreach (GameObject dropPoint in dropPoints.dropPoints)
        {
            GameObject newAsset = assetPool.TakeFromAssetPool(ObjectTypes.Asteroid ,  gameObject.transform , dropPoint.transform.position );
            newAsset.SetActive(true);
        }

        isActive = true;
    }

}
