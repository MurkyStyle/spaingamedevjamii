using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public bool onGround;
    public Transform footRef;
    public float velX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movX;

        movX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);

        onGround = Physics2D.OverlapCircle(footRef.position, 1, 1 << 8); // cuando el pie está cerca del suelo

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(
                new Vector2(0, jumpForce), 
                ForceMode2D.Impulse
                );
        }
    }

    private void FixedUpdate()
    {
        //camera movement
        Vector3 camStartPos = Camera.main.transform.position;
        Vector3 camFinalPos = transform.position - new Vector3(0, 0, 20);

        Camera.main.transform.position = Vector3.Lerp(camStartPos,camFinalPos,.05f);        
    }
}
