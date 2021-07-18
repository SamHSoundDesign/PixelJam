using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public List<Bullet> bulletList= new List<Bullet>();


    public void FireBullet(GameObject bullet , Transform bulletsParent)
    {
        GameObject newBulletObject = Instantiate(bullet, transform.position, Quaternion.identity, bulletsParent);
        Bullet newBullet = newBulletObject.GetComponent<Bullet>();
        newBullet.UpdateBulletRB(newBullet.gameObject.GetComponent<Rigidbody2D>() , this);
        bulletList.Add(newBullet);

    }

    public void FixedUpdates()
    {
        if(bulletList.Count != 0)
        {
            foreach(Bullet bullet in bulletList)
            {
                bullet.BulletMove();
            }

        }
    }

}
