using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFiring : PlayerState
{
    private PlayerController player;
    private Rigidbody2D rb;
    private GameObject projectilePrefab;
    private GameObject speedPrefab;
    private PlayerState returnState;

    private int cooldown;

    public PlayerStateFiring(PlayerController player, Rigidbody2D rb, int c, GameObject prefab, GameObject sprefab, PlayerState rstate)
    {
        this.player = player;
        this.rb = rb;
        this.cooldown = c;
        this.projectilePrefab = prefab;
        this.speedPrefab = sprefab;
        this.returnState = rstate;
    }

    public void handleSpace()
    {
        //cannot fire again
    }

    public void handleCollision()
    {
        //TODO
    }

    public void advanceState()
    {
        cooldown--;
        if (cooldown <= 0 )
        {
            player.setState(returnState);
        }
    }
}
