using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{

    private AstroidShower astroidShower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AstroidShower astroidShower = transform.parent.GetComponentInParent<AstroidShower>();
            astroidShower.ActivateAsteroidShower();

        }
    }
}
