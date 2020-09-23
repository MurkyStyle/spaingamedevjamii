using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject player;
    private Transform playerTrans;

    private Rigidbody2D bulletRb;

    public float bulletSpeed;
    public float bulletLife;

    void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerTrans.localScale.x > 0)
        {
            bulletRb.velocity = new Vector2(bulletSpeed, bulletRb.velocity.y);
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
        }
        else if(playerTrans.localScale.x < 0)
        {
            bulletRb.velocity = new Vector2(-bulletSpeed, bulletRb.velocity.y);
            transform.localScale = new Vector3(-0.05f, 0.05f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }

    //TODO: si impacta contra enemigo
    private void OnTriggerEnter2D(Collider2D col)
    {
        //TODO: si impacta contra enemigo ira y enojo y es bala corazón
        //TODO: si impacta contra enemigo tristeza y es bala sonrisa
        //TODO: si impacta contra enemigo realidad y es bala Sí

        //if(col.GetComponent<LayerMask>() == LAYER)
        //{
        //    Destroy(this.gameObject);
        //}
        
    }
}
