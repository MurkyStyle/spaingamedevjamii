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
            bulletRb.velocity = new Vector2(bulletSpeed * Time.deltaTime, bulletRb.velocity.y);
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
        }
        else if(playerTrans.localScale.x < 0)
        {
            bulletRb.velocity = new Vector2(-bulletSpeed * Time.deltaTime, bulletRb.velocity.y);
            transform.localScale = new Vector3(-0.05f, 0.05f, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }
}
