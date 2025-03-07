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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Equals("SpaceShipNormal"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
