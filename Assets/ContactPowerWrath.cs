using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPowerWrath : MonoBehaviour
{
    //[SerializeField] private Collider2D _collider2D;
    [SerializeField] private int _damage;
    
    private void Activate(GameObject victim)
    {
        //victim.TakeDamage();
        print("jaja");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")){
            Activate(collision.gameObject);
        }
    }
}

