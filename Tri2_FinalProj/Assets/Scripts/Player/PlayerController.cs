using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState state;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    public GameObject speedPrefab;


    public int borderLeft;
    public int borderRight;
    public int velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = new PlayerStateNormal(this, rb, projectilePrefab, speedPrefab);
        borderLeft = -10;
        borderRight = 10;
        velocity = 4;
    }

    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            rb.velocity = new Vector2(velocity, 0);
        }
        if (Input.GetKeyDown("left"))
        {
            rb.velocity = new Vector2(-velocity, 0);
        }
        if (!(Input.GetKeyDown("left")) && Input.GetKeyUp("right"))
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (!(Input.GetKeyDown("right")) && Input.GetKeyUp("left"))
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            state.handleSpace();
        }

        state.advanceState();
    }

    public void setState(PlayerState s)
    {
        state = s;
    }

    public void changeVelocity()
    {
        if (velocity == 10)
        {
            velocity = 4;
        } else
        {
            velocity = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("FireUp"))
        {
            UnityEngine.Debug.Log("fireup");
            Destroy(other.gameObject);
            state = new PlayerStateFireup(this, rb, projectilePrefab, speedPrefab, 500);
        }
        if (other.gameObject.tag.Equals("SpeedUp"))
        {
            UnityEngine.Debug.Log("speedup");
            Destroy(other.gameObject);
            state = new PlayerStateSpeedup(this, rb, projectilePrefab, speedPrefab, 500);
        }
    }
}
