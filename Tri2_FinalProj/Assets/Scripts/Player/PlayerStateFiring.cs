using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFiring : PlayerState
{
    private PlayerController player;
    private Rigidbody2D rb;
    private GameObject projectilePrefab;

    private int cooldown;

    public PlayerStateFiring(PlayerController player, Rigidbody2D rb, int c, GameObject prefab)
    {
        this.player = player;
        this.rb = rb;
        this.cooldown = c;
        this.projectilePrefab = prefab;
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
            player.setState(new PlayerStateNormal(player, rb, projectilePrefab));
        }
    }
}
