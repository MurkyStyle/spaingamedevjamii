using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float maxX;
    public float speed;
    public bool upDown,sube;
    Vector3 posicionInicial;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (upDown)
        {
            if (sube)
            {
                if (transform.position.y < posicionInicial.y + maxX)
                    rb.velocity = new Vector2(rb.velocity.x, speed);
                else
                    sube = false;
            }else
            {
                if (transform.position.y > posicionInicial.y - maxX)
                    rb.velocity = new Vector2(rb.velocity.x, speed * -1);
                else
                    sube = true;
            }
        }
        else
        {
            if (sube)
            {
                if (transform.position.x < posicionInicial.x + maxX)
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                else
                    sube = false;
            }
            else
            {
                if (transform.position.x > posicionInicial.x - maxX)
                    rb.velocity = new Vector2(speed * -1, rb.velocity.y);
                else
                    sube = true;
            }
        }
    }
}
