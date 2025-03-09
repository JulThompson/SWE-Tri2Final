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

    private ICommand moveRightCommand;
    private ICommand moveLeftCommand;
    private ICommand stopMovementCommand;
    private ICommand shootCommand;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = new PlayerStateNormal(this, rb, projectilePrefab);
        borderLeft = -10;
        borderRight = 10;
        velocity = 4;

        moveRightCommand = new MoveRightCommand(this);
        moveLeftCommand = new MoveLeftCommand(this);
        stopMovementCommand = new StopMovementCommand(this);
        shootCommand = new ShootCommand(state);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRightCommand.Execute();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeftCommand.Execute();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            stopMovementCommand.Execute();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootCommand.Execute();
        }

        state.advanceState();
    }

    public void setState(PlayerState s)
    {
        state = s;
    }
}
