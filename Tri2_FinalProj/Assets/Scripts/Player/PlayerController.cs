using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState state;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;


    public int borderLeft;
    public int borderRight;
    public int velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = new PlayerStateNormal(this, rb, projectilePrefab);
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
            UnityEngine.Debug.Log("space hit");
            state.handleSpace();
        }

        state.advanceState();
    }

    public void setState(PlayerState s)
    {
        state = s;
    }
}
