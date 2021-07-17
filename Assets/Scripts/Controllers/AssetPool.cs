using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPool
{
    private List<GameObject> asteroids;
    private GameObject asteroidPrefab;
    private GameObject assetPool;

    private GameController gameController;

    public AssetPool(GameObject assetPool , GameController gameController , GameObject asteroidPrefab , Asteroid[] asteroids)
    {
        this.asteroids = ConvertAsteroidArrayToList(asteroids);
        this.asteroidPrefab = asteroidPrefab;
        this.gameController = gameController;
        this.assetPool = assetPool;
    }
    public GameObject TakeFromAssetPool(ObjectTypes objectType , Transform parent , Vector2 position)
    {
        GameObject asset;

        if(objectType == ObjectTypes.Asteroid)
        {
            if(asteroids.Count != 0)
            { 
                asset = asteroids[0];
                asteroids.RemoveAt(0);
            
            }
            else
            {
                asset = gameController.InitiateAsset(asteroidPrefab);
            }
        }
        else
        {
            asset = asteroids[0];
            asteroids.RemoveAt(0);
        }

        asset.transform.SetParent(parent);
        asset.transform.position = position;

        return asset;
    }
    public void ReturnToAssetPool(ObjectTypes objectType , GameObject asset)
    {
        asset.SetActive(false);

        if (objectType == ObjectTypes.Asteroid)
        {
            asteroids.Add(asset);
            asset.transform.position = assetPool.transform.position;
            asset.transform.parent = assetPool.transform;
        }
        else
        {
            asteroids.Add(asset);
            asset.transform.position = assetPool.transform.position;
        }
    }
    private List<GameObject> ConvertAsteroidArrayToList(Asteroid[] array)
    {
        List<GameObject> newList = new List<GameObject>();

        foreach (Asteroid asteroid in array)
        {
            newList.Add(asteroid.gameObject);
        }

        return newList;

    }


}
