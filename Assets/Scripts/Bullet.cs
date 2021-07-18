using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletSpeed = 25f;
    private Gun gun;
    private int bulletDamage = 100;
    public void BulletMove()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    public void UpdateBulletRB(Rigidbody2D rb , Gun gun)
    {
        this.rb = rb;
        this.gun = gun;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HI");
            collision.gameObject.GetComponent<EnemyData>().TakeDamage(bulletDamage);
        }

        gun.bulletList.Remove(this);
        Destroy(gameObject);

    }


}
