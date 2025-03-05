using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int velocity = 12;
    public Rigidbody2D rb;
    public BoxCollider2D collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        rb.velocity = new Vector2(0, velocity);
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name.Equals("SpaceShipNormal")))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
