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
    bool hugAttack;
    Animator anim;

    void Awake()
    {
        nextFireTime = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        // INPUTS
        movX = Input.GetAxis("Horizontal");
        movJump = Input.GetButtonDown("Jump");
        hugAttack = Input.GetButtonDown("Hug");

        // Jump
        onGround = Physics2D.OverlapCircle(footRef.position, 1, 1 << 8); // cuando el pie está cerca del suelo

        if (movJump && onGround)
        {
            PlayerJump();
            anim.SetBool("jump", true);
        }
        //else
        //{
        //    anim.SetBool("jump", false);
        //}
        
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

        // Hug

        if (hugAttack)
        {
            Debug.Log("Abrazo Fuerte!");
        }

        // Anim

        if(movX != 0 && onGround )
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

    }

    private void FixedUpdate()
    {
        //player movement
        rb.velocity = new Vector2(velX * movX * Time.fixedDeltaTime, rb.velocity.y);

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
        anim.SetBool("jump", false);
    }

    //TODO: cuando colisione con enemigos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: si salta sobre enemigo confusión
        //TODO: si abraza al enemigo dolor y culpa y está de color azul
    }
}
