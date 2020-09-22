using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    //var public
    public float jumpForce;
    public bool onGround;
    public Transform footRef;
    public float velX;
    public Transform bulletSpawner;
    public GameObject[] bulletPrefab;
    public float cooldownTime;

    //var inputs
    float movX;
    bool movJump;
    float nextFireTime;

    void Awake()
    {
        nextFireTime = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // INPUTS
        movX = Input.GetAxis("Horizontal");
        movJump = Input.GetButtonDown("Jump");        

        // Jump
        onGround = Physics2D.OverlapCircle(footRef.position, 1, 1 << 8); // cuando el pie está cerca del suelo

        if (movJump && onGround)
        {
            PlayerJump();
        }
        
        // Shoot
        if (Time.time > nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerShooting(bulletPrefab[0]);
                nextFireTime = Time.time + cooldownTime;
            }
            else if (Input.GetButtonDown("Fire2"))                
            {
                PlayerShooting(bulletPrefab[1]);
                nextFireTime = Time.time + cooldownTime;
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                PlayerShooting(bulletPrefab[2]);
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void FixedUpdate()
    {
        //player movement
        rb.velocity = new Vector2(velX * movX * Time.deltaTime, rb.velocity.y);

        if (movX < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (movX > 0) transform.localScale = new Vector3(1, 1, 1);

        //camera movement
        Vector3 camStartPos = Camera.main.transform.position;
        Vector3 camFinalPos = transform.position - new Vector3(0, 0, 20);

        Camera.main.transform.position = Vector3.Lerp(camStartPos,camFinalPos,.05f);        
    }

    public void PlayerShooting(GameObject bulletType)
    {
        Instantiate(bulletType, bulletSpawner.position, bulletSpawner.rotation);
    }

    public void PlayerJump()
    {
        rb.AddForce(
                new Vector2(0, jumpForce),
                ForceMode2D.Impulse
                );
    }
}
